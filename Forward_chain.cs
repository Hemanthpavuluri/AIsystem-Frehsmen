namespace forward_chainalgo
{
    public class forward_chain
    {
        Dictionary<int, string> fvknowledgebase = new Dictionary<int, string>();
        Dictionary<string, string> fvariable_list = new Dictionary<string, string>();
        Dictionary<int, string> fclause_var_list = new Dictionary<int, string>();
        Dictionary<int, string> fwknbaseconditions = new Dictionary<int, string>();
        Dictionary<int, string> fconcl_ans_list = new Dictionary<int, string>();
        Dictionary<string, string> fvquestions = new Dictionary<string, string>();
        Queue<string> concl_varbl_qu = new Queue<string>();
        Dictionary<int, Array> check = new Dictionary<int, Array>();

        public forward_chain()
        {
            string basePath = "fw_data/";
            int i;
            using (StreamReader inp = new StreamReader(Path.Combine(basePath, "Project1-FW_Knowledgebase.txt")))
            {
                i = 10;
                while (!inp.EndOfStream)
                {
                    string line = inp.ReadLine();
                    fvknowledgebase[i] = line;
                    i += 10;
                }
            }

            using (StreamReader inp = new StreamReader(Path.Combine(basePath, "Project1-fw_varlist.txt")))
            {
                while (!inp.EndOfStream)
                {
                    string line = inp.ReadLine();
                    fvariable_list[line] = "NI";
                }
            }

            using (StreamReader inp = new StreamReader(Path.Combine(basePath, "Project1-FW_clause_vrbl.txt")))
            {
                i = 1;
                while (!inp.EndOfStream)
                {
                    string line = inp.ReadLine();
                    fclause_var_list[i] = line;
                    i++;
                }
            }

            using (StreamReader inp = new StreamReader(Path.Combine(basePath, "Project1-FW_clause_vrbl.txt")))
            {
                i = 10;
                while (!inp.EndOfStream)
                {
                    string[] arr = new string[6];
                    for (int j = 0; j < 6; j++)
                    {
                        string l = inp.ReadLine();
                        if (l != "p")
                        {
                            arr[j] = l;
                        }
                    }
                    check[i] = arr;
                    i += 10;
                }
            }

            using (StreamReader inp = new StreamReader(Path.Combine(basePath, "Project1-FW_kbasecondition.txt")))
            {
                i = 1;
                while (!inp.EndOfStream)
                {
                    string line = inp.ReadLine();
                    fwknbaseconditions[i] = line;
                    i++;
                }
            }

            using (StreamReader inp = new StreamReader(Path.Combine(basePath, "Project1-fw-conclans.txt")))
            {
                i = 10;
                while (!inp.EndOfStream)
                {
                    string line = inp.ReadLine();
                    fconcl_ans_list[i] = line;
                    i += 10;
                }
            }

            fvquestions.Add("InterestedPhysics", "Are you interested in Physics?");
            fvquestions.Add("InterestedEngines", "Does Engines makes you happy?");
            fvquestions.Add("GoodDrawings", "Do you consider yourself good at Drawing?");
            fvquestions.Add("LoadBearing", "Do you want to know how the tall skyscrappers are built?");
            fvquestions.Add("LearnHacking", "Interested to learn about Hacking and how to keep servers safe?");
            fvquestions.Add("ReadNovels", "Do you read a lot of novles?");
            fvquestions.Add("FictionOnly", "If you read Novels, do you only read Fiction?");
            fvquestions.Add("AttendConcerts", "Do you attend a lot of concerts?");
            fvquestions.Add("Dances", "Are you interested to learn different types of dances?");
            fvquestions.Add("RecordConcert", "Do you want to record performances? Concerts in particular?");
            fvquestions.Add("Company", "Do you want to start a company?");
            fvquestions.Add("MarketProduct", "Interested to learn how products are marketed?");
            fvquestions.Add("ManageProduct", "Want to learn Marketing Management?");
            fvquestions.Add("Trading", "Want to learn how Stock markets work?");
            fvquestions.Add("Budget", "Interested to understand how large corporations manage their budgets?");
            fvquestions.Add("Surgery", "Want to perform surgeries?");
            fvquestions.Add("Heart", "Interested to operate on Heart?");
            fvquestions.Add("Clinical", "If you do not want to perform surgery then do you want to treat patients at a clinic?");
            fvquestions.Add("Skin", "Do you want to treat patients with Skin diseases?");
            fvquestions.Add("Gmed", "Do you want to be a general Medicine Practitioner?");
            fvquestions.Add("MapMaking", "Do you want to learn about the science of Map Making?");
            fvquestions.Add("Weather", "Would you like to research on weather changes over time?");
            fvquestions.Add("Forecast", "Do you want to build tech to Forcast weather which alerts people of catastrophies?");
            fvquestions.Add("Environment", "Would you be interested to Study organisms and Environments?");
            fvquestions.Add("Earthquakes", "Want to study Earthquakes?");
            fvquestions.Add("Theory", "Interested in learning the theories of Karl Marx, Max Wever, Emmile Durkhaim ?");
            fvquestions.Add("SocietyAndHealth", "Are you Interested in learning and examining the interaction between society and health?");
            fvquestions.Add("VillageLifeAndPeople", "Are you interested in learning about village life and the people living there?");
            fvquestions.Add("UrbanLifeAndPeople", "Are you interested in the area of sociology which studies the way of life of urban people?");
            fvquestions.Add("IndustryRelations", "Do you consider yourself interested in the branch of sociology that is concerned with the industrial relationship of human beings?");
            fvquestions.Add("EngineeringInAgriculture", "Are you interested in applying engineering science and technology to agricultural production and processing?");
            fvquestions.Add("BioSystems", "Are you interested in studying biology?");
            fvquestions.Add("MaintainFarms", "Do you like to maintain farms?");
            fvquestions.Add("AgriDiseases", "Do you like to do research on agricultural plants?");
            fvquestions.Add("AgriLaws", "Are you interested in studying laws relating to domestic agriculture and imports of foreign agricultural products?");
            fvquestions.Add("Teaching", "Are you interested in teaching students?");
            fvquestions.Add("Career", "Do you like to support students to develop their career?");
            fvquestions.Add("Guide", "Do you like to guide the students in a path?");
            fvquestions.Add("Office", "Do you like to provide office support?");
            fvquestions.Add("Industry", "Are you more likely to research on brands and convience companies join your organization?");
            fvquestions.Add("Writenews", "Are you interested in news articles?");
            fvquestions.Add("LiveCoverage", "Are you intrested to give live coverage news around the globe?");
            fvquestions.Add("Editnews", "Are you interested in editing the information which is collected for news?");
            fvquestions.Add("Presentnews", "Do you like to present news?");
            fvquestions.Add("Freelance", "Are you interested to work as a freelance?");
            fvquestions.Add("TrainAthletes", "Do you like train the atheletes?");
            fvquestions.Add("TreatAthletes", "Do you like to diagnose atheletes?");
            fvquestions.Add("ParticularSport", "Do you want to specialise in any particular sport?");
            fvquestions.Add("GoodCommunication", "Are your communications skills good?");
            fvquestions.Add("OrganiseEvents", "Do you like to organise events?");


        }

        public string AreaFW(string profession)
        {
            int flag = 0;
            int i = 1;
            string ans = "";
            int rule = 0;
            fvariable_list["Profession"] = profession;
            if (profession != "Sorry could not find any rule to determine profession.")
            {
                concl_varbl_qu.Enqueue("Profession");
                int k, num = 1, j;
                while (i <= 300)
                {
                    k = 0;
                    for (j = num; j < num + 6; j++)
                    {
                        if (fclause_var_list[j] != "p")
                        {
                            rule = ((i / 6) + 1) * 10;

                            if (fvariable_list[fclause_var_list[j]] == "NI")
                            {
                                string res;

                                Console.WriteLine(fvquestions[fclause_var_list[j]] + " -->YES/NO: ");
                                res = Console.ReadLine().ToUpper();
                                if (res == "YES" || res == "NO")
                                {
                                    fvariable_list[fclause_var_list[j]] = res;
                                }
                                else
                                {
                                    Console.WriteLine("Wrong input detected:" + "\n" + "Please enter only YES or NO ");
                                    Console.WriteLine(fvquestions[fclause_var_list[j]] + " -->YES/NO: ");
                                    res = Console.ReadLine().ToUpper();
                                    fvariable_list[fclause_var_list[j]] = res;
                                }
                            }

                            if (fvariable_list[fclause_var_list[j]] == fwknbaseconditions[j])
                            {
                                flag = 1;
                                k++;
                            }
                            else
                            {
                                flag = 0;
                                break;
                            }
                        }
                    }
                    if (flag == 1)
                    {
                        ans = fconcl_ans_list[rule];
                        concl_varbl_qu.Clear();
                        break;
                    }
                    num = num + 6;
                    i = i + 6;
                }
                return ans;
            }
            else
            {
                ans = "Sorry could not determine area for the given profession";
                return ans;
            }


        }
    }
}

