using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Miniwd.Services
{
    public class AIService
    {
        private Flat _flat;
        public AIService(Flat flat)
        {
            _flat = flat;
        }

        public Boolean BuyOrNot()
        {
            string argsString = GetArgsInString(_flat);
            return ExecutePythonScript(argsString);
        }

        private Boolean ExecutePythonScript(string args)
        {
            string pythonScript = @".\Artificial_Intelligence\predict.py";
            string pythonCommand = "Python";
            string result;
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = pythonCommand;
            start.Arguments = pythonScript + " " + args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    result = reader.ReadToEnd();
                }
            }
            return result.Replace(Environment.NewLine, "").Equals("1") ? true : false;
        }

        private string GetArgsInString(Flat flat)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("KindOfOperation "); sb.Append(flat.KindOfOperation.Equals("W") ? 0 : 1);  // W->0 K->1

            sb.Append(" KindOfSpace "); sb.Append(flat.KindOfSpace.Equals("P") ? 0 : 1); //P->0 M->1

            sb.Append(" RoomsAmount "); sb.Append(flat.RoomsAmount.ToString());

            //sb.Append(" BathroomsAmount "); sb.Append(flat.BathroomsAmount.ToString());

            sb.Append(" LocationRating "); sb.Append(flat.LocationRating);

            sb.Append(" Size "); sb.Append(flat.Size.ToString());

            sb.Append(" Price "); sb.Append(flat.Price.ToString());

            sb.Append(" Standard "); sb.Append(flat.Standard.ToString());

            sb.Append(" Floor "); sb.Append(flat.Floor.ToString());

            sb.Append(" City "); sb.Append(flat.City);

            sb.Append(" UserRoomsAmount "); sb.Append(flat.UserRoomsAmount);

            sb.Append(" UserPrice "); sb.Append(flat.UserPrice);

            sb.Append(" UserStandard "); sb.Append(flat.UserStandard);

            sb.Append(" UserLocationRating "); sb.Append(flat.UserLocationRating);

            return sb.ToString();
        }
    }
}
