/*
Name:		Erica Sungok Kim
Date:		August, 2018
Purpose:	To implement major functions
Version:	1.0
*/

#include "fileusage.hpp"
using namespace std;

//function to parse input data to a container
deque<string> parseInput(int argc, char * argv[])
{
	deque<string> dArg;
	for (int i = 1; i < argc; ++i)
		dArg.push_back(argv[i]);

	return dArg;
}

//function to parse switches and insert in a container
void parseSwitch(string strSwitch, map<char, int> & mSwitches)
{
	size_t c = strSwitch.find('c');
	size_t j = strSwitch.find('j');
	size_t m = strSwitch.find('m');
	size_t x = strSwitch.find('x');

	//if any of c or j or m or x are combined, exit
	if (c != string::npos && j != string::npos)
	{
		cerr << "Error: cannot combine x, c, j, or m switches\n";
		exit(1);
	}
	if (c != string::npos && m != string::npos)
	{
		cerr << "Error: cannot combine x, c, j, or m switches\n";
		exit(1);
	}
	if (c != string::npos && x != string::npos)
	{
		cerr << "Error: cannot combine x, c, j, or m switches\n";
		exit(1);
	}
	if (j != string::npos && m != string::npos)
	{
		cerr << "Error: cannot combine x, c, j, or m switches\n";
		exit(1);
	}
	if (j != string::npos && x != string::npos)
	{
		cerr << "Error: cannot combine x, c, j, or m switches\n";
		exit(1);
	}
	if (m != string::npos && x != string::npos)
	{
		cerr << "Error: cannot combine x, c, j, or m switches\n";
		exit(1);
	}

	//add switches in map, but ignore unaccptable switches
	for (size_t i = 1; i < strSwitch.size(); ++i)
	{
		for (char x : "cjmxrRshv")
		{
			if (strSwitch[i] == x)
				mSwitches[x] = 1;
		}
	}
}

//function to scan and parse the current folder and all its subfolders
void parseInfo(map<char, int>& mSwitches, regex expression, path const& folder, vector<ExtRecord>& vExtRecord, vector<FolderRecord>& vFolderRecord)
{
	//Create a directory iterator passing it the folder object
	directory_iterator dir_it(folder);

	//Create another iterator to end
	directory_iterator dir_end;

	//read directory information and begin the search
	while (dir_it != dir_end)
	{
		try
		{
			if (is_directory(dir_it->status()))
			{
				if (mSwitches['r'])
					parseInfo(mSwitches, expression, dir_it->path(), vExtRecord, vFolderRecord);
			}
			else if (is_regular_file(dir_it->status()))
			{
				//read folders' data and insert corresponding data to vector
				vector<ExtRecord>::iterator it = vExtRecord.begin();

				for (; it != vExtRecord.end(); ++it)
				{
					if (dir_it->path().extension().string() == it->extName)
						break;
				}

				if (it != vExtRecord.end())
				{
					it->extCount++;
					it->filesizeCount += file_size(dir_it->path());
				}
				else
				{
					if (mSwitches['c'])
					{
						regex reg(".(c|cpp|h|hpp|hxx)");
						if (regex_match(dir_it->path().extension().string(), reg))
						{
							ExtRecord extRec(dir_it->path().extension().string(), 1, file_size(dir_it->path()));
							vExtRecord.push_back(extRec);
						}
					}
					else if (mSwitches['j'])
					{
						regex reg(".(java|class)");
						if (regex_match(dir_it->path().extension().string(), reg))
						{
							ExtRecord extRec(dir_it->path().extension().string(), 1, file_size(dir_it->path()));
							vExtRecord.push_back(extRec);
						}
					}
					else if (mSwitches['m'])
					{
						regex reg(".(avi|mpeg|mp4|3gp|wmv|mkv)");
						if (regex_match(dir_it->path().extension().string(), reg))
						{
							ExtRecord extRec(dir_it->path().extension().string(), 1, file_size(dir_it->path()));
							vExtRecord.push_back(extRec);
						}
					}
					else if (mSwitches['x'])
					{
						if (regex_match(dir_it->path().extension().string(), expression))
						{
							ExtRecord extRec(dir_it->path().extension().string(), 1, file_size(dir_it->path()));
							vExtRecord.push_back(extRec);
						}
					}
					else
					{
						ExtRecord extRec(dir_it->path().extension().string(), 1, file_size(dir_it->path()));
						vExtRecord.push_back(extRec);
					}
				}

				//read subfolders' data and insert corresponding data to vector
				vector<FolderRecord>::iterator it_f = vFolderRecord.begin();

				for (; it_f != vFolderRecord.end(); ++it_f)
				{
					if (dir_it->path().extension().string() == it_f->extName && dir_it->path().parent_path().string() == it_f->folderName)
						break;
				}
				if (it_f != vFolderRecord.end())
				{
					it_f->extNumPerFolder++;
				}
				else
				{
					if (mSwitches['c'])
					{
						regex reg(".(c|cpp|h|hpp|hxx)");
						if (regex_match(dir_it->path().extension().string(), reg))
						{
							FolderRecord folRec(dir_it->path().extension().string(), 1, dir_it->path().parent_path().string());
							vFolderRecord.push_back(folRec);
						}
					}
					else if (mSwitches['j'])
					{
						regex reg(".(java|class)");
						if (regex_match(dir_it->path().extension().string(), reg))
						{
							FolderRecord folRec(dir_it->path().extension().string(), 1, dir_it->path().parent_path().string());
							vFolderRecord.push_back(folRec);
						}
					}
					else if (mSwitches['m'])
					{
						regex reg(".(avi|mpeg|mp4|3gp|wmv|mkv)");
						if (regex_match(dir_it->path().extension().string(), reg))
						{
							FolderRecord folRec(dir_it->path().extension().string(), 1, dir_it->path().parent_path().string());
							vFolderRecord.push_back(folRec);
						}
					}
					else if (mSwitches['x'])
					{
						if (regex_match(dir_it->path().extension().string(), expression))
						{
							FolderRecord folRec(dir_it->path().extension().string(), 1, dir_it->path().parent_path().string());
							vFolderRecord.push_back(folRec);
						}
					}
					else
					{
						FolderRecord folRec(dir_it->path().extension().string(), 1, dir_it->path().parent_path().string());
						vFolderRecord.push_back(folRec);
					}
				}
			}
		}
		catch (filesystem_error & ex)
		{
			cerr << ex.what() << endl;
		}
		++dir_it;
	}

	//v is in the switches , sort folder record data
	if (mSwitches['v'])
	{
		sort(vFolderRecord.begin(), vFolderRecord.end(), byFolderAscending);
	}
	
	//s is in the switches , ascending sort by size
	if (mSwitches['s'] && !mSwitches['R'])
	{
		sort(vExtRecord.begin(), vExtRecord.end(), bySizeAscending);
	}	
	//s and R are in the switches , descending sort by size
	else if (mSwitches['s'] && mSwitches['R'])
	{
		sort(vExtRecord.begin(), vExtRecord.end(), bySizeDescending);
	}	
	//R is in the switches , descending sort by extension
	else if (!mSwitches['s'] && mSwitches['R'])
	{
		sort(vExtRecord.begin(), vExtRecord.end(), byExtDescending);
	}
	//ascending sort by extension is default
	else
	{
		sort(vExtRecord.begin(), vExtRecord.end(), byExtAscending);
	}		
}


