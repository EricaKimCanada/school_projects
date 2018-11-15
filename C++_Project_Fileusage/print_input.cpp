/*
Name:		Erica Sungok Kim
Date:		August, 2018
Purpose:	To print folder, extension, filesize information
			To print summary and detail report
Version:	1.0
*/

#include "fileusage.hpp"
using namespace std;

//function print the result
void printInput(map<char, int> & mSwitches,string strExpression,path const& folder,vector<ExtRecord> & vExtRecord, vector<FolderRecord> & vFolderRecord)
{	
	string options = "";
	for (auto x : mSwitches)
	{
		if(x.first != 'c' && x.first != 'j' && x.first != 'm' && x.first != 'x' && x.second == 1)
			options += x.first;
	}

	string extPrint;
	if (mSwitches['c'])
		extPrint = "\\.(c|cpp|h|hpp|hxx)";
	
	else if (mSwitches['j'])
		extPrint = "\\.(java|class)";
	
	else if (mSwitches['m'])
		extPrint = "\\.(avi|mpeg|mp4|3gp|wmv|mkv)";
	
	else if (mSwitches['x'])
		extPrint = strExpression;
	
	else
		extPrint = ".*";
		
	//print detail report and summary
	unsigned long totalExtCount = 0;
	unsigned long long totalFileSize = 0;

	cout << options << " ext: " << extPrint << " folder: " << folder << endl;

	if (mSwitches['h'])
	{
		cout << "Usage: fileusage [-hrRsv(c|j|m|x [regularexpression])] [folder]" << endl;
	}
	else
	{
		if (mSwitches['v'])
		{
			cout << endl << "Detail Report" << endl;
			cout << "-------------" << endl << endl;
			
			set<string> sStr;
			for (FolderRecord x : vFolderRecord)
			{
				sStr.insert(x.extName);
			}
			for (string sExt : sStr)
			{
				string extDetail = "";
				int countFolder = 0;
				for (FolderRecord fr : vFolderRecord)
				{
					if (sExt == fr.extName)
					{
						extDetail += "       " + to_string(fr.extNumPerFolder) + ":       " + fr.folderName + "\n";
						++countFolder;
					}
				}
				cout << sExt << " (" + to_string(countFolder) << " folders)" << "\n" << extDetail;
			}
		}

		cout << endl <<  "Summary: " << folder << endl << endl;

		cout << right << setw(13) << "Ext" << " : " << right << setw(4) << "#" << " : " << right << setw(13) << "Total" << endl;

		cout << "-------------" << " : " << "----" << " : " << "-------------" << endl;

		for (auto x : vExtRecord)
		{
			cout << right << setw(13) << x.extName << " : " << right << setw(4) << x.extCount << " : " << right << setw(13) << x.filesizeCount << endl;

			totalExtCount += x.extCount;
			totalFileSize += x.filesizeCount;
		}

		cout << "-------------" << " : " << "----" << " : " << "-------------" << endl;

		cout << right << setw(13) << vExtRecord.size() << " : " << right << setw(4) << totalExtCount << " : " << right << setw(13) << totalFileSize << endl;
	}
	cout << endl;
}
