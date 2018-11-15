/*
Module:			filebackup_main.cpp
Date:			Sep 29, 2018
Author:			Erica Kim
Description:	A file backup application that uses a FileManager class that is defined
				in a separate header file and implemented in another source file.
*/

#include "FileManager.hpp"
#include "FileInfo.hpp"
using namespace std;
using namespace std::experimental::filesystem;

int main(int argc, char * argv[])
{
	locale here("");
	cout.imbue(here);
	cout << "filebackup (c) 2018, Erica Kim" << endl << endl;

	//if arguments are more than 3, error and exit
	if (argc > 3)
	{
		cerr << "Error: invalid input" << endl;
		return EXIT_FAILURE;
	}

	// Checking if source directory is vaild
	if (argc > 1) 
	{
		file_status sourDirCheck;
		try
		{
			sourDirCheck = status(argv[1]);
		}
		catch (filesystem_error &e)
		{
			cerr << e.what() << endl;
		}

		if (is_directory(sourDirCheck) == false)
		{
			cerr << "Error: Source Directory is invaild" << endl;
			return EXIT_FAILURE;
		}
	}

	if (argc == 1)
	{
		FileManager file_m1;
		file_m1.backup(); 
		file_m1.report();
	}

	if (argc == 2)
	{
		FileManager file_m2(argv[1]);
		FileManager copyFile_m2(file_m2);
		copyFile_m2.report();
	}

	if (argc == 3)
	{
		FileManager file_m3(argv[1], argv[2]);
		file_m3.backup();
		file_m3.report();
	}
}