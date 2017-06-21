using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDistanceShortest
{
    class TowerDistance
    {
        private string InputValues { get; set; }
        public string ErrorMessage { get; set; }

        public TowerDistanceResult TowerDistanceShortest { get; set; }

        public TowerDistance(string inputValues)
        {
            InputValues = inputValues;
        }

        public bool TowerCalculation()
        {
            // Check that we have an input string to work with
            if(InputValues.Length == 0)
            {
                ErrorMessage = "Input string must be supplied";
                return false;
            }

            string[] values = InputValues.Split(' ');

            // Check that we have values to work with
            if (values.Length < 2)
            {
                ErrorMessage = "Input string must be in the form 'x1,y1, x2,y2, x3,y3,... etc'";
                return false;
            }

            Tower[] tArray = new Tower[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                var t = new Tower();
                string[] coords = values[i].Split(',');

                // Check that we have a pair of coords to work with
                if (coords.Length < 2)
                {
                    ErrorMessage = "Input string must be in the form 'x1,y1, x2,y2, x3,y3,... etc'";
                    return false;
                }

                // Check that coords are supplied and are numeric
                t.x = CheckCoordNumeric(coords[0]);
                t.y = CheckCoordNumeric(coords[1]);
                if (t.x == null || t.y == null)
                {
                    ErrorMessage = "Input string must be in the form 'x1,y1, x2,y2, x3,y3,... etc'.  All x and y values must be numeric.";
                    return false;
                }


                t.TowerName = string.Format("Tower {0}", i);

                // Add the Tower name and coords to the array
                tArray[i] = t;

            }

            // Create a list for tower distances
            List<TowerDistanceResult> TowerDistances = new List<TowerDistanceResult>();

            // Compare all the distances and add them to the list
            for (int j = 0; j < values.Length; j++)
            {
                for (int i = (j + 1); i < values.Length; i++)
                {
                    TowerDistanceResult tdr = new TowerDistanceResult();
                    tdr.TowerDistanceResultName = string.Format("{0} ({1},{2}) and {3} ({4},{5})", tArray[j].TowerName, tArray[j].x, tArray[j].y, tArray[i].TowerName, tArray[i].x, tArray[i].y);
                    tdr.Distance = calculateDistance(tArray[j].x, tArray[i].x, tArray[j].y, tArray[i].y);

                    TowerDistances.Add(tdr);

                }
            }

            // Create a version of the list ordered by distance
            var tdResult = TowerDistances.OrderBy(x => x.Distance);

            // Populate TowerDistanceShortest with the top result of that ordered list (shortest distance)
            TowerDistanceShortest = tdResult.First();

            return true;
        }

        private int? CheckCoordNumeric(string coord)
        {
            int id;
            return int.TryParse(coord, out id) ? (int?)id : null;
        }

        private double calculateDistance(int? x1, int? x2, int? y1, int? y2)
        {
            double dx = x1.Value - x2.Value;
            double dy = y1.Value - y2.Value;
            return Math.Sqrt((dx * dx) + (dy * dy));
        }

    }

    class Tower
    {
        public string TowerName { get; set; }
        public int? x { get; set; }
        public int? y { get; set; }
    }

    class TowerDistanceResult
    {
        public string TowerDistanceResultName { get; set; }
        public double Distance { get; set; }
    }



}
