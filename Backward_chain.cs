namespace backward_chainalgo
{
	public class backward_chain
	{
		//variable declarations
		Stack<int> rule_num=new Stack<int>(), clause_num=new Stack<int>();
		Dictionary<int, string> knowledgebase=new Dictionary<int, string>();
		Dictionary<int, string> kbaseconditions = new Dictionary<int, string>();
		Dictionary<int, string> concl_list = new Dictionary<int, string>();
        Dictionary<int, string> concl_ans_list= new Dictionary<int, string>();
		Dictionary<int, string> clause_var_list = new Dictionary<int, string>();
		Dictionary<string, string> concl_ans1 = new Dictionary<string, string>();
		Dictionary<string, string> variable_list= new Dictionary<string, string>();
		Dictionary<string, string> vquestions= new Dictionary<string, string>();
		Dictionary<int, int> concl1 = new Dictionary<int, int>();
		Dictionary<string, string> concl2 = new Dictionary<string, string>();

		//constructor
		public backward_chain()
		{
			//file1 read
			string filePath = "bw_data/Project1-back_knowledge_base.txt";
			using (StreamReader reader = new StreamReader(filePath))
			{
				int i = 10;
				while (!reader.EndOfStream)
				{
					string line = reader.ReadLine();
					knowledgebase[i] = line;
					i += 10;
				}
			}
			//intialising variable list
			filePath = "bw_data/Project1-variable_list.txt";
			using (StreamReader reader = new StreamReader(filePath))
			{
				while (!reader.EndOfStream)
				{
					string line = reader.ReadLine();
					variable_list[line] = "NI";
				}
			}

			//intialising conclusion list
			filePath = "bw_data/Project1-conclusion_list.txt";
			using (StreamReader reader = new StreamReader(filePath))
			{
				int i = 10;
				while (!reader.EndOfStream)
				{
					string line = reader.ReadLine();
					concl_list[i] = line;
					i += 10;
				}
			}
			//intialising clause variable list
			filePath = "bw_data/Project1-clause_variable.txt";
			using (StreamReader reader = new StreamReader(filePath))
			{
				int i = 1;
				while (!reader.EndOfStream)
				{
					string line = reader.ReadLine();
					clause_var_list[i] = line;
					i++;
				}
			}

			filePath = "bw_data/Project1-kbasecondition.txt";

			using (StreamReader reader = new StreamReader(filePath))
			{
				int i = 1;
				while (!reader.EndOfStream)
				{
					string line = reader.ReadLine();
					kbaseconditions[i] = line;
					i++;
				}
			}

			filePath = "bw_data/Project1-conclans.txt";
			using (StreamReader reader = new StreamReader(filePath))
			{
				int i = 10;
				while (!reader.EndOfStream)
				{
					string line = reader.ReadLine();
					concl_ans_list[i] = line;
					i += 10;
				}
			}

			vquestions.Add("Freshman", "Are you enrolled as a Freshman?");
			vquestions.Add("Build", "Do you like to build or invent something?");
			vquestions.Add("TechAndHealth", "Are you interested to combine technology with health?");
			vquestions.Add("Health", "Do you want to study about human health?");
			vquestions.Add("Crop", "Are you interested in studying about food growth and crops?");
			vquestions.Add("Concerts", "Do you like attending lot of concerts?");
			vquestions.Add("Games", "Do you like to play outdoor games and follow sports?");
			vquestions.Add("Product", "Are you interested in developing a product for the market?");
			vquestions.Add("Acorientation", "Do you have academic orientation?");
			vquestions.Add("Fieldwork", "Do you like to do field works?");
			vquestions.Add("MapMaking", "Are you interested in creating maps?");
			vquestions.Add("Society", "Do you like to study human behaviour and society?");

		}

		public void askquestion()
		{
			string res;
			int finalans = 1;
			while (rule_num.Count != 0)
			{
				finalans = 1;
				int num = clause_num.Peek();
				int crule = rule_num.Peek();
				for (int i = num; i <= num + 7; i++)
				{
					if (clause_var_list[i] != "p")
					{
						string clvariable = clause_var_list[i];
						if (variable_list.ContainsKey(clause_var_list[i]))
						{
							if (variable_list[clause_var_list[i]] == "NI")
							{
								Console.WriteLine(vquestions[clause_var_list[i]] + " -->YES/NO: ");
								res = Console.ReadLine().ToUpper();
								if (res == "YES" || res == "NO")
								{
									variable_list[clause_var_list[i]] = res;
								}
								else
								{
									Console.WriteLine("Wrong input detected:" + "\n" + "Please enter only YES or NO ");
									Console.WriteLine(vquestions[clause_var_list[i]] + " -->YES/NO: ");
									res = Console.ReadLine().ToUpper();
									variable_list[clause_var_list[i]] = res;
								}
							}
							if (variable_list[clause_var_list[i]] == kbaseconditions[i])
							{
								finalans = 1;
								continue;
							}
							else
							{
								finalans = 0;
								concl1.Add(rule_num.Peek(), finalans);
								string found_conclusion = concl_list[rule_num.Peek()];
								if (found_conclusion != "Profession")
								{
									concl2.Add(found_conclusion, "NO");
								}
								rule_num.Pop();
								clause_num.Pop();
								break;
							}

						}
						else
						{

							if (concl1.ContainsKey(crule))
							{
								clause_num.Pop();
								rule_num.Pop();

								continue;
							}

							if ((concl2.ContainsKey(clvariable)) && concl2[clvariable] == "YES")
							{
								continue;
							}
							else
							{

								if ((concl2.ContainsKey(clvariable)) && concl2[clvariable] == "NO")
								{
									clause_num.Pop();
									rule_num.Pop();
									string found_conclusion = concl_list[crule];
									if (found_conclusion != "Profession")
									{
										concl2.Add(found_conclusion, "NO");
									}
									break;
								}
								foreach (var kvp in concl_list)
								{
									if (clvariable == kvp.Value && kvp.Value != "Profession")
									{
										int clause_no = (((kvp.Key / 10) - 1) * 8) + 1;
										rule_num.Push(kvp.Key);
										clause_num.Push(clause_no);
										break;
									}
								}
								break;
							}
						}
					}
					else
					{

						if (i - num == 7)
						{
							string conclusion = concl_list[rule_num.Peek()];
							//Console.WriteLine(conclusion);
							if (conclusion == "Profession")
							{
								concl2.Add(conclusion, concl_ans_list[rule_num.Peek()]);
							}
							else
							{
								concl2.Add(conclusion, "YES");
							}
							clause_num.Pop();
							rule_num.Pop();
						}
						continue;
					}

					int finished_processing_clause = clause_num.Peek();
					clause_num.Pop();
					finished_processing_clause++;
					clause_num.Push(finished_processing_clause);
				}
			}
		}


		//backward chain function
		public string ProfessionBW()
		{
			int i = 10;

			string ans = "";
			while (i <= 120)
			{
				if ("Profession" == concl_list[i])
				{
					rule_num.Push(i);
					clause_num.Push((((i / 10) - 1) * 8) + 1);
					askquestion();
					if (concl2.ContainsKey("Profession"))
					{
						ans = concl2["Profession"];
						if (ans == "NO")
						{
							Console.WriteLine();
							Console.WriteLine("Cannot determine profession:");
							Console.WriteLine();
						}
						else
						{
							return ans;
						}
						break;
					}
				}

				i = i + 10;
			}
			if (ans == "")
			{
				Console.WriteLine("------------------------------------------------");
				Console.WriteLine("Sorry could not find any rule to determine profession.  ");
				Console.WriteLine("-------------------------------------------------");
			}

			return ans;

		}
	}
}

