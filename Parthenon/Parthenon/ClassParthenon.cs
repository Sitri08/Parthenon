using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Data.SqlClient;

namespace Parthenon
{
    public struct setare
    {
        public int language; //0 RO, 1 EN
        public string profilePicture; //id-ul imaginii de profil
        public string gender;
        public string birthDate;
        public bool editRights; 
        public bool generalTutorials; 
        public bool startTutorial;
    };

    public class ClassParthenon
    {
        //obtine setarile contului
        public static void IncarcaDateUtilizator(ref setare x)
        {
            string[] date = System.IO.File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "user_settings.txt");
            for (int i = 0; i < 7; i++) date[i] = date[i].Split(':')[1].Trim().Trim(';');

            if (date[0][0].Equals('R')) x.language = 0; else x.language = 1;
            x.profilePicture = date[1];
            x.gender = date[2];
            x.birthDate = date[3];
            x.editRights = Convert.ToBoolean(date[4]);
            x.generalTutorials = Convert.ToBoolean(date[5]);
            x.startTutorial = Convert.ToBoolean(date[6]);
        }

        //salveaza setarile contului
        public static void ActualizeazaDateUtilizator(setare x)
        {
            string language;
            if (x.language == 0) language = "RO"; else language = "EN";
            string dateComplet = String.Format(
                "language: {0};\nprofilePicture: {1};\ngender: {2};\nbirthDate: {3};\neditRights: {4};\ngeneralTutorials: {5};\nstartTutorial: {6};",
                language, x.profilePicture, x.gender, x.birthDate, x.editRights, x.generalTutorials, x.startTutorial);
            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "user_settings.txt", dateComplet);
        }
    }
}
