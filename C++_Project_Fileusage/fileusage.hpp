/*
Name:		Erica Sungok Kim
Date:		August, 2018
Purpose:    Header file
			To create a ExtRecord class and a FolderRecord class
			To write predicate functions for the class
			To declare major functions
Version:	1.0
*/
#include <iostream>
#include <string>
#include <vector>
#include <deque>
#include <map>
#include <set>
#include <iomanip>
#include <regex>
#include <locale>

#include <filesystem>
using namespace std::experimental::filesystem::v1;

//declare class to store extension record data
class ExtRecord
{
public:
	std::string extName;
	unsigned long extCount;
	unsigned long long filesizeCount;

	ExtRecord() {}; 
	ExtRecord(std::string eName, unsigned long eCount, uintmax_t fCount) :
		extName(eName), extCount(eCount), filesizeCount(fCount) {};
};

//declare class to store folder record data
class FolderRecord
{
public:
	std::string extName;
	unsigned long extNumPerFolder;
	std::string folderName;

	FolderRecord() {};
	FolderRecord(std::string eName, unsigned long enpf, std::string fName) :
		extName(eName), extNumPerFolder(enpf), folderName(fName) {};
};

//predicate function byExt to pass to sort algorithm, ascending sort
inline bool byExtAscending(ExtRecord const& lhs, ExtRecord const& rhs)
{
	return lhs.extName < rhs.extName;
}

//predicate function byExt to pass to sort algorithm, descending sort
inline bool byExtDescending(ExtRecord const& lhs, ExtRecord const& rhs)
{
	return lhs.extName > rhs.extName;
}

//predicate function bySize to pass to sort algorithm, ascending sort
inline bool bySizeAscending(ExtRecord const& lhs, ExtRecord const& rhs)
{
	return lhs.filesizeCount < rhs.filesizeCount;
}

//predicate function bySize to pass to sort algorithm, descending sort
inline bool bySizeDescending(ExtRecord const& lhs, ExtRecord const& rhs)
{
	return lhs.filesizeCount > rhs.filesizeCount;
}

//predicate function byFolder to pass to sort algorithm, ascending sort
inline bool byFolderAscending(FolderRecord const& lhs, FolderRecord const& rhs)
{
	return lhs.folderName < rhs.folderName;
}

//predicate function byFolder to pass to sort algorithm, descending sort
inline bool byFolderDescending(FolderRecord const& lhs, FolderRecord const& rhs)
{
	return lhs.folderName > rhs.folderName;
}

//function to parse input data to a container
std::deque<std::string> parseInput(int argc, char * argv[]);

//function to parse switches and insert in a container
void parseSwitch(std::string, std::map<char, int> &);

//function to scan and parse the current folder and all its subfolders
void parseInfo(std::map<char,int>&,std::regex,path const&,std::vector<ExtRecord>&,std::vector<FolderRecord>&);

//function print the result
void printInput(std::map<char, int>&,std::string,path const&,std::vector<ExtRecord>&,std::vector<FolderRecord>&);