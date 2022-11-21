using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;

namespace Metec.MVBDClient
{
    static class PARAMS
    {
        public const double MAX_SCALE = 50;
        public const double MIN_SCALE = 0.1;
        public const double SCALE_STEP = 1.2;
        public const double MOVE_STEP = 3;  // in pins
        public const double ROT_STEP = 10;
        public const int LONG_PRESS = 400;
        public const int BLANK_ID = -1;
        public const int NULL_ID = -2;
        public const int DOUDBLE_CLICK_THRES = 2;

        public const int VOICE_SELF = 29;
        public const int VOICE_BACK = 30;
        public const int VOICE_FORWARD = 31;

        public static ExtraInfo AGENT_INFO = new ExtraInfo { 
            Id = -1,
            IsVisible = true,
            Type = -1,
            Source = null,
            SemanticLabel = VOICE_SELF
        };
    }

    public class SceneInst
    {
        // {0=Normal instance, 1=Large instance, 2=Wall, 3=Door}
        public bool isValid;
        public int type;
        public int semantic_label;     // ScanNet labels
        public int id;
        public double cx, cy; // center
        public double x0, y0, x1, y1;  // boundingbox parameters: up left corner  and up right corner; if type == 2 , represents two end points 
        public int[] source;
        public bool isFlashing;
        public string name;
        
        public SceneInst()
        {
            isValid = false;
            type = 0;
            semantic_label = 0;
            id = -1;
            cx = 0;
            cy = 0;
            x0 = 0;
            y0 = 0;
            x1 = 0;
            y1 = 0;
            source = null;
            name = null;
        }
    }

    public class Semantics
    {
        public static string[] labels = {
            "water",
            "sidewalk",
            "sign",
            "building",
            "tree",
            "bench",
            "rock",
            "sign",
            "dustbin",
            "bush",
            "light",
            "shadow",
            "man",
            "girl",
            "person",
            "grass",
            "truck",
            "branch",
            "leaf",
            "armrest",
            "leg",
            "bag",
            "bird",
            "pant",
            "shoe",
            "jacket",
            "near",
            "on",
            "have",
            "me",
            "back",
            "forward",
        };

        public static string[] labels_chinese = {
            "湖",
            "人行道",
            "路标",
            "建筑",
            "树",
            "长椅",
            "石头",
            "路标",
            "垃圾桶",
            "灌木",
            "路灯",
            "阴凉",
            "男性",
            "女孩",
            "成年人",
            "草丛",
            "树干",
            "树枝",
            "叶子",
            "扶手",
            "长椅腿",
            "书包",
            "鸟",
            "裤子",
            "鞋子",
            "夹克",
            "在附近",
            "在上面",
            "拥有",
            "自己",
            "返回",
            "展开",
        };
    }
    public class Renderer
    {
        /// <summary>
        /// apply 2D transformation to the input point (x0, y0)
        /// first translate to the view center (cx, cy),
        /// then apply scale and rotation.
        /// </summary>
        /// <param name="x0">input x coord</param>
        /// <param name="y0">input y coord</param>
        /// <param name="cx">view center x coord</param>
        /// <param name="cy">view center y coord</param>
        /// <param name="scale"></param>
        /// <param name="rot"></param>
        public static double[] clipspace_trans_2D(double x0, double y0, double cx, double cy, double scale, double rot)
        {
            // translate
            //double x1 = x0 - cx;
            //double y1 = y0 - cy;
            double x1 = x0;
            double y1 = y0;
            // scale
            x1 *= scale;
            y1 *= scale;
            // rotation: https://en.wikipedia.org/wiki/Rotation_matrix
            return new double[] { x1 * Math.Cos(rot / 180 * Math.PI) - y1 * Math.Sin(rot / 180 * Math.PI),
                                  x1 * Math.Sin(rot / 180 * Math.PI) + y1 * Math.Cos(rot / 180 * Math.PI) };
        }

        public static double[] get_display_space_coords(int width, int height, double[] pos)
        {
            return new double[] { pos[0] + width / 2, height / 2 - pos[1]};
        }

        //public static void setPin(int[,] array, int width, int height, int x, int y, int val)
        //{
        //    if (x >= 0 && x < width && y >= 0 && y < height)
        //        array[x, y] = val;
        //}

        public static void setPin(ExtraInfo[,] array, int width, int height, int x, int y, ExtraInfo val)
        {
            if (x >= 0 && x < width && y >= 0 && y < height && val != null)
            {
                // do not let visible line blocked by invisible line
                if (array[x, y] == null || array[x, y].IsVisible == false || (array[x, y].Type == 4 && val.Type != 4))
                {
                    array[x, y] = val;
                }
            }
        }

        public static void render_circle(ExtraInfo[,] array, int width, int height, int size, double[] pos, ExtraInfo val)
        {
            if (size % 2 != 1)
            {
                Console.WriteLine("Exception: " + "size should be odd number");
                return;
            }
            // convert from clipspace to display space
            double[] coord = get_display_space_coords(width, height, pos);

            int x0 = (int)Math.Round(coord[0]);
            int y0 = (int)Math.Round(coord[1]);

            int r = size / 2;

            // if outside of visible area
            if (x0 + r < 0 || x0 - r >= width || y0 + r < 0 || y0 - r >= height)
            {
                return;
            }

            for (int i = -r; i <= r; i++ )
            {
                for (int j = -r; j <= r; j++)
                {
                    if (i * i + j * j <= r * r)
                    {
                        setPin(array, width, height, x0 + j, y0 + i, val);
                    }
                }
            }
        }

        public static void render_line(ExtraInfo[,] array, int width, int height, double[] pos0, double[] pos1, ExtraInfo val)
        {
            // https://en.wikipedia.org/wiki/Bresenham%27s_line_algorithm
            double[] pos0_disp = get_display_space_coords(width, height, pos0);
            double[] pos1_disp = get_display_space_coords(width, height, pos1);

            int x0 = (int)Math.Round(pos0_disp[0]);
            int xEnd = (int)Math.Round(pos1_disp[0]);
            int y0 = (int)Math.Round(pos0_disp[1]);
            int yEnd = (int)Math.Round(pos1_disp[1]);

            double slope = (pos1_disp[1] - pos0_disp[1]) / (pos1_disp[0] - pos0_disp[0]);
            int dx = Math.Abs(xEnd - x0), dy = Math.Abs(yEnd - y0);

            //for a normal line
            if (dx != 0 && dy != 0)
            {
                //for line with |slope| < 1
                if (Math.Abs(slope) < 1)
                {
                    int p = 2 * dy - dx;
                    int twoDy = 2 * dy, twoDyMinusDx = 2 * (dy - dx);
                    int x, y;

                    // Determine which endpoint to use as start position 
                    if (pos0_disp[0] > pos1_disp[0])
                    {
                        x = xEnd;
                        y = yEnd;
                        xEnd = x0;
                    }
                    else
                    {
                        x = x0;
                        y = y0;
                    }
                    setPin(array, width, height, x, y, val);

                    while (x < xEnd)
                    {
                        x++;
                        if (p < 0)
                            p += twoDy;
                        else
                        {
                            //decrement y if slope is negative
                            if (slope < 0)
                                y--;
                            //increment if slope is positive
                            else
                                y++;
                            p += twoDyMinusDx;
                        }
                        setPin(array, width, height, x, y, val);
                    }
                }
                //for line with |slope| > 1: switch x and y
                else
                {
                    int p = 2 * dx - dy;
                    int twoDx = 2 * dx, twoDxMinusDy = 2 * (dx - dy);
                    int x, y;

                    // Determine which endpoint to use as start position 
                    if (pos0_disp[1] > pos1_disp[1])
                    {
                        y = yEnd;
                        x = xEnd;
                        yEnd = y0;
                    }
                    else
                    {
                        y = y0;
                        x = x0;
                    }
                    setPin(array, width, height, x, y, val);

                    while (y < yEnd)
                    {
                        y++;
                        if (p < 0)
                            p += twoDx;
                        else
                        {
                            //decrement x if slope is negative
                            if (slope < 0)
                                x--;
                            //increment x if slope is positive
                            else
                                x++;
                            p += twoDxMinusDy;
                        }
                        setPin(array, width, height, x, y, val);
                    }
                }
            }

            //horizontal line
            else if (dy == 0)
            {
                int x, y;
                y = (int)Math.Round(pos0_disp[1]);//rd(start.getY());
                // Determine which endpoint to use as start position 
                if (pos0_disp[0] > pos1_disp[0])
                {
                    x = xEnd;
                    xEnd = x0;
                }
                else
                {
                    x = x0;
                }
                for (int i = x; i <= xEnd; i++)
                    setPin(array, width, height, i, y, val);
            }
            //vertical line
            else if (dx == 0)
            {
                int x, y;
                x = (int)Math.Round(pos0_disp[0]);//rd(pos0[0]);
                // Determine which endpoint to use as start position 
                if (pos0_disp[1] > pos1_disp[1])
                {
                    y = yEnd;
                    yEnd = y0;
                }
                else
                {
                    y = y0;
                }
                for (int i = y; i <= yEnd; i++)
                    setPin(array, width, height, x, i, val);
            }

        }

        static void swap(ref int a, ref int b) { int tmp = a; a = b; b = tmp; }
        static void swap(ref float a, ref float b) { float tmp = a; a = b; b = tmp; }
        // render 
        static void _fill_left_triangle(ExtraInfo[,] array, int width, int height, int x1, int y1, int x2, int y2, int x3, int y3, ExtraInfo val)
        {
            float y_up = y1;
            float y_down = y1;
            float dy_up = (float)(y2 - y1) / (x2 - x1);
            float dy_down = (float)(y3 - y1) / (x3 - x1);

            if (dy_up > dy_down) swap(ref dy_up, ref dy_down);

            for (int i = x1; i <= x2; i++)
            {
                // fill line 
                for (int j = (int)Math.Round(y_up); j <= (int)Math.Round(y_down); j++)
                {
                    setPin(array, width, height, i, j, val);
                }
                // update end points
                y_up += dy_up;
                y_down += dy_down;
            }
        }

        static void _fill_right_triangle(ExtraInfo[,] array, int width, int height, int x1, int y1, int x2, int y2, int x3, int y3, ExtraInfo val)
        {
            float y_up = y3;
            float y_down = y3;
            float dy_up = (float)(y3 - y1) / (x3 - x1);
            float dy_down = (float)(y2 - y3) / (x2 - x3);

            if (dy_up < dy_down) swap(ref dy_up, ref dy_down);


            for (int i = x3; i >= x2; i--)
            {
                // fill line 
                for (int j = (int)Math.Round(y_up); j <= (int)Math.Round(y_down); j++)
                {
                    setPin(array, width, height, i, j, val);
                }
                // update end points
                y_up -= dy_up;
                y_down -= dy_down;
            }
        }

        public static void render_triangle(ExtraInfo[,] array, int width, int height, double[] p1, double[] p2, double[] p3, ExtraInfo val)
        {
            // https://cglearn.codelight.eu/pub/computer-graphics/task/bresenham-triangle-1 
            // transform to display space coords

            var p1_disp = get_display_space_coords(width, height, p1);
            var p2_disp = get_display_space_coords(width, height, p2);
            var p3_disp = get_display_space_coords(width, height, p3);


            int x1 = (int)Math.Round(p1_disp[0]);
            int y1 = (int)Math.Round(p1_disp[1]);
            int x2 = (int)Math.Round(p2_disp[0]);
            int y2 = (int)Math.Round(p2_disp[1]);
            int x3 = (int)Math.Round(p3_disp[0]);
            int y3 = (int)Math.Round(p3_disp[1]);


            // sort along x axis
            void swap(ref int a, ref int b) { int tmp = a; a = b; b = tmp; }

            if (x2 > x3) { swap(ref x2,ref x3); swap(ref y2, ref y3); }
            if (x1 > x2) { swap(ref x1,ref x2); swap(ref y1, ref y2); }
            if (x2 > x3) { swap(ref x2, ref x3); swap(ref y2, ref y3); }


            if (x1 < x2)
            {
                _fill_left_triangle(array, width, height, x1, y1, x2, y2, x3, y3, val);
            }
            if (x2 < x3)
            {
                _fill_right_triangle(array, width, height, x1, y1, x2, y2, x3, y3, val);
            }
        }

        public static void render_rectangle(ExtraInfo[,] array, int width, int height, double[] center, double[] corner0, double[] corner1, ExtraInfo val)
        {
            double[] get_mirror_point(double[] p1, double[] anchor)
            {
                return new double[] { 2 * anchor[0] - p1[0], 2 * anchor[1] - p1[1] };
            }

            //var p1_disp = get_display_space_coords(width, height, corner0);
            //var p2_disp = get_display_space_coords(width, height, corner1);
            //var center_disp = get_display_space_coords(width, height, center);

            var corner2 = get_mirror_point(corner0, center);
            var corner3 = get_mirror_point(corner1, center);

            render_triangle(array, width, height, corner0, corner2, corner1, val);
            render_triangle(array, width, height, corner0, corner2, corner3, val);
        }

        //public static void render_agent(int[,] array, int width, int height,  double[] pos, double orientation, int val)
        //{
        //    double radius = 2;
        //    int step = 8 * (int)radius - 8;
        //    double curr_theta = 0;

        //    var pos1 = new double[] { pos[0] + radius * System.Math.Cos(orientation / 180 * Math.PI),
        //                          pos[1] + radius * System.Math.Sin(orientation / 180 * Math.PI) };

        //    double[] coord = get_display_space_coords(width, height, pos);
        //    double[] coord_1 = get_display_space_coords(width, height, pos1);

        //    int x0 = (int)Math.Round(coord[0]);
        //    int y0 = (int)Math.Round(coord[1]);

        //    for (int i = 0 ; i < step; i++)
        //    {

        //        int x = (int)Math.Round(x0 + radius * System.Math.Cos(curr_theta));
        //        int y = (int)Math.Round(y0 + radius * System.Math.Sin(curr_theta));

        //        setPin(array, width, height, x, y, val);
        //        curr_theta += 2 * Math.PI / step;
        //    }
        //    render_line(array, width, height, pos, pos1, val);
        //}
        public static void render_agent(ExtraInfo[,] array, int width, int height, double[] pos, double orientation, ExtraInfo val)
        {
            double radius = 5;

            var pos1 = new double[] { pos[0] + radius * System.Math.Cos(orientation / 180 * Math.PI)/ 2,
                                  pos[1] + radius * System.Math.Sin(orientation / 180 * Math.PI) / 2 };
            var pos2 = new double[] { pos[0] + radius * System.Math.Cos(orientation / 180 * Math.PI),
                                  pos[1] + radius * System.Math.Sin(orientation / 180 * Math.PI) };

            render_circle(array, width, height, (int)radius, pos, val);
            render_line(array, width, height, pos1, pos2, val);
        }
    }

    /// <summary>Representation for a scene</summary>
    public class SceneData
    {
        public List<SceneInst> _data;
        // display parameters
        // mode=0 -> ego centric ;  mode = 1 -> static mode
        public int mode;
        public double orientation_agent;    // 0~360, 0 represents +y direction
        public double orientation_map;      // only used for static mode
        public double scale;
        public double x0, y0;               // agent position
        public double x1, y1;               // map center

        public int point_size;
        public int current_suffix;

        public SceneData() : this(0, 0, 0, 1.0, 0, 0,0,0, 5)
        {
        }

        public SceneData(int _mode, double _orientation_agent, double _orientation_map, double _scale, double _x0, double _y0, double _x1, double _y1, int _point_size)
        {
            _data = new List<SceneInst>();
            mode = _mode;
            orientation_agent = _orientation_agent;
            orientation_map = _orientation_map;
            scale = _scale;
            x0 = _x0; // agent center
            y0 = _y0; // agent center
            x1 = _x1; 
            y1 = _y1;
            point_size = _point_size;
            current_suffix = 1;
        }

        public bool save(string path)
        {

            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(this);
            // Console.WriteLine(serializedResult);
            try
            {
                StreamWriter sw = new StreamWriter(path);
                //Write a line of text
                sw.WriteLine(serializedResult);
                sw.Close();
                Console.WriteLine(serializedResult);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return false;
            }
            return true;
        }

        public void print()
        {
            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(this);
            Console.WriteLine(serializedResult);
        }

        public static SceneData load(string path)
        {
            String json_string;
            var serializer = new JavaScriptSerializer();

            try
            {
                StreamReader sr = new StreamReader(path);
                //Read the first line of text
                json_string = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return new SceneData();
            }

            SceneData ret = serializer.Deserialize<SceneData>(json_string);
            return ret;
        }

        // render scene to a buffer
        public bool render(ExtraInfo[,] array, int width, int height)
        {
            // 1) translation to the view center
            // 2) apply scale and rotation transformation (clipspace coords)
            // 3) offset to the display center and rasterize
            if (mode == 0)
            {
                SceneData.clear(array, width, height);
                for (int i = 0; i < _data.Count; i++)
                {
                    // if (!_data[i].isValid) continue;
                    ExtraInfo info = ExtraInfo.GetFromSceneInst(_data[i]);
                    if (_data[i].type == 2 || _data[i].type == 4)
                    {
                        double[] pos0_clipspace = Renderer.clipspace_trans_2D(
                            _data[i].x0, _data[i].y0, x0, y0, scale, 90 - orientation_agent);
                        double[] pos1_clipspace = Renderer.clipspace_trans_2D(
                            _data[i].x1, _data[i].y1, x0, y0, scale, 90 - orientation_agent);
                        Renderer.render_line(array, width, height, pos0_clipspace, pos1_clipspace, info);
                    }
                    else if(_data[i].type == 0)
                    {
                        double[] pos_clipspace = Renderer.clipspace_trans_2D(
                            _data[i].cx, _data[i].cy, x0, y0, scale, 90 - orientation_agent);

                        Renderer.render_circle(array, width, height, point_size, pos_clipspace, info);
                    }
                    else if (_data[i].type == 1)
                    {
                        double[] corner0_clipspace = Renderer.clipspace_trans_2D(
                            _data[i].x0, _data[i].y0, x0, y0, scale, 90 - orientation_agent);
                        double[] corner1_clipspace = Renderer.clipspace_trans_2D(
                            _data[i].x1, _data[i].y1, x0, y0, scale, 90 - orientation_agent);
                        double[] center_clipspace = Renderer.clipspace_trans_2D(
                            _data[i].cx, _data[i].cy, x0, y0, scale, 90 - orientation_agent);
                        Renderer.render_rectangle(array, width, height, center_clipspace, corner0_clipspace, corner1_clipspace, info);
                    }
                    else if (_data[i].type == 3)
                    {
                        double[] pos_clipspace = Renderer.clipspace_trans_2D(_data[i].cx, _data[i].cy, x0, y0, scale, 90 - orientation_agent);
                        Renderer.render_circle(array, width, height, (int)Math.Round(_data[i].x0), pos_clipspace, info);
                    }
                }
                double[] agent_clipspace = new double[] { 0,0};
                Renderer.render_agent(array, width, height, agent_clipspace, 90, PARAMS.AGENT_INFO);
            }
            else if (mode == 1)  
            {
                SceneData.clear(array, width, height);
                for (int i = 0; i < _data.Count; i++)
                {
                    ExtraInfo info = ExtraInfo.GetFromSceneInst(_data[i]);
                    //if (!_data[i].isValid) continue;
                    if (_data[i].type == 2 || _data[i].type == 4)
                    {
                        double[] pos0_clipspace = Renderer.clipspace_trans_2D(
                            _data[i].x0, _data[i].y0, x0, y0, scale, orientation_map);
                        double[] pos1_clipspace = Renderer.clipspace_trans_2D(
                            _data[i].x1, _data[i].y1, x0, y0, scale, orientation_map);
                        //double[] pos0_clipspace = { _data[i].x0, _data[i].y0 };
                        //double[] pos1_clipspace = { _data[i].x1, _data[i].y1 };
                        Renderer.render_line(array, width, height, pos0_clipspace, pos1_clipspace, info);
                    }
                    else if(_data[i].type == 0)
                    {
                        double[] pos_clipspace = Renderer.clipspace_trans_2D(
                            _data[i].cx, _data[i].cy, x1, y1, scale, orientation_map);

                        Renderer.render_circle(array, width, height, point_size, pos_clipspace, info);
                    }
                    else if (_data[i].type == 1)
                    {
                        double[] corner0_clipspace = Renderer.clipspace_trans_2D(
                            _data[i].x0, _data[i].y0, x1, y1, scale, orientation_map);
                        double[] corner1_clipspace = Renderer.clipspace_trans_2D(
                            _data[i].x1, _data[i].y1, x1, y1, scale, orientation_map);
                        double[] center_clipspace = Renderer.clipspace_trans_2D(
                            _data[i].cx, _data[i].cy, x1, y1, scale, orientation_map);
                        Renderer.render_rectangle(array, width, height, center_clipspace, corner0_clipspace, corner1_clipspace, info);
                    }
                    else if (_data[i].type == 3)
                    {
                        //double[] pos_clipspace = { _data[i].cx, _data[i].cy };
                        double[] pos_clipspace = Renderer.clipspace_trans_2D(_data[i].cx, _data[i].cy, x0, y0, scale, 90 - orientation_agent);
                        Renderer.render_circle(array, width, height, (int)Math.Round(_data[i].x0), pos_clipspace, info);
                    }
                }
                double[] agent_clipspace = Renderer.clipspace_trans_2D(
                            x0, y0, x1, y1, scale, orientation_map);
                Renderer.render_agent(array, width, height, agent_clipspace, orientation_agent + orientation_map, PARAMS.AGENT_INFO);
            }
            else
            {
                Console.WriteLine("Exception: " + "Not implemented error.");
                return false;
            }
            return true;
        }


        public static void flush(ExtraInfo[,] array, bool[,] array_display, int width, int height, bool flashing_show=true)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    array_display[i, j] = array[i, j] != null && array[i, j].IsVisible;
                    if (array[i, j] != null && flashing_show == false && array[i, j].IsFlashing == true)
                    {
                        array_display[i, j] = false;
                    }
                }
            }
        }

        public static void clear(bool[,] array, int width, int height)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    array[i, j] = false;
                }
            }
        }

        public static void clear(int[,] array, int width, int height)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    array[i, j] = -1;
                }
            }
        }

        public static void clear(ExtraInfo[,] array, int width, int height)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    array[i, j] = null;
                }
            }
        }

        public void set_view_center(double x, double y)
        {
            x1 = x;
            y1 = y;
        }

        public void set_scale(double s)
        {
            scale = s;
        }

        public void set_agent_orientation(double theta)
        {
            orientation_agent = theta;
        }

        public void zoom_in()
        {
            scale *= PARAMS.SCALE_STEP;
            scale = scale > PARAMS.MAX_SCALE ? PARAMS.MAX_SCALE : scale;
        }

        public void zoom_out()
        {
            scale /= PARAMS.SCALE_STEP;
            scale = scale > PARAMS.MAX_SCALE ? PARAMS.MAX_SCALE : scale;
        }

        public void move_up()
        {
            x0 += PARAMS.MOVE_STEP / scale * Math.Cos(orientation_agent / 180 * Math.PI);
            y0 += PARAMS.MOVE_STEP / scale * Math.Sin(orientation_agent / 180 * Math.PI);
        }

        public void move_down()
        {
            x0 -= PARAMS.MOVE_STEP / scale * Math.Cos(orientation_agent / 180 * Math.PI);
            y0 -= PARAMS.MOVE_STEP / scale * Math.Sin(orientation_agent / 180 * Math.PI);
        }

        public void move_right()
        {
            x0 += PARAMS.MOVE_STEP / scale * Math.Sin(orientation_agent / 180 * Math.PI);
            y0 -= PARAMS.MOVE_STEP / scale * Math.Cos(orientation_agent / 180 * Math.PI);
        }
        public void move_left()
        {
            x0 -= PARAMS.MOVE_STEP / scale * Math.Sin(orientation_agent / 180 * Math.PI);
            y0 += PARAMS.MOVE_STEP / scale * Math.Cos(orientation_agent / 180 * Math.PI);
        }

        public void rot_left()
        {
            orientation_agent += PARAMS.ROT_STEP;
        }

        public void rot_right()
        {
            orientation_agent -= PARAMS.ROT_STEP;
        }

        public void set_mode(int _mode)
        {
            mode = _mode;
        }

        public string get_label_text(ExtraInfo[,] array, int width, int height, int px, int py, bool chinese)
        {
            if (px < 0 || px >= width || py < 0 || py >= height) return "";
            if (array[px, py] == null || !array[px, py].IsVisible)
            {
                return "";
            }
            return array[px, py].Name;
            //int label_id = array[px, py].SemanticLabel % 1000;
            //if (label_id >= 0 && label_id < Semantics.labels.Length)
            //{
            //    if (!chinese)
            //    {
            //        return Semantics.labels[label_id];
            //    }
            //    else { 
            //        return Semantics.labels_chinese[label_id];
            //    }
            //}
            //return "";
        }

        public string get_semantic_label(int label_id, bool chinese)
        {
            if (!chinese)
            {
                return Semantics.labels[label_id];
            }
            else
            {
                return Semantics.labels_chinese[label_id];
            }
        }

        public int get_suffix(ExtraInfo[,] array, int width, int height, int px, int py)
        {
            if (px < 0 || px >= width || py < 0 || py >= height) return 0;
            if (array[px, py] == null)
            {
                return -1;
            }
            int file_suffix = array[px, py].SemanticLabel;
            return file_suffix;
        }

        public int get_id(ExtraInfo[,] array, int width, int height, int px, int py)
        {
            if (px < 0 || px >= width || py < 0 || py >= height) return 0;
            ExtraInfo info = array[px, py];
            if (info == null)
            {
                return -1;
            }
            return info.Id;
        }

        public ExtraInfo get_extra_info(ExtraInfo[,] array, int width, int height, int px, int py)
        {
            if (px < 0 || px >= width || py < 0 || py >= height) return null;
            return array[px, py];
        }
    }
}
