/*
Module:			FileManager.cpp
Date:			Sep 29, 2018
Author:			Erica Kim
Description:	An implementation of the FileManager class.
*/

#include "FileInfo.hpp"
#include "FileManager.hpp"
using namespace std;
using namespace std::experimental::filesystem;

FileManager::FileManager() : sourceDir_("."), backupDir_("C:\\backup")
{
	find();
}

FileManager::FileManager(path s_dir) : sourceDir_(s_dir), backupDir_("C:\\backup") {}

FileManager::FileManager(path s_dir, path b_dir) : sourceDir_(s_dir), backupDir_(b_dir)
{
	find();
}

/*
copy constructor : copy information from the FileManager object
then backup files
*/
FileManager::FileManager(FileManager const& orig) : sourceDir_(orig.sourceDir_), backupDir_(orig.backupDir_)
{
	find();
	backup();
}

/*
copy assignment operator : copy information from the FileManager object to this object
*/
FileManager& FileManager::operator = (FileManager const&rhs)
{
	this->sourceDir_ = rhs.sourceDir_;
	this->backupDir_ = rhs.backupDir_;
	return *this;
}

/*
find method: to find appropriate files from source directory and load into vector.
*/
void FileManager::find()
{
	recursive_directory_iterator dir_it(sourceDir_);
	recursive_directory_iterator dir_end;

	for (dir_it; dir_it != dir_end; ++dir_it)
	{
		try
		{
			bool is_copy = true;
			std::regex reg(".(c|cpp|h|hpp)");
			if (regex_match(dir_it->path().extension().string(), reg))
			{
				for (auto vf : vFileInfo)
				{
					if (dir_it->path().filename().string() == vf.fileName_)
						is_copy = false;
				}

				FileInfo fInfo(dir_it->path().filename().string(), is_copy, file_size(dir_it->path()), dir_it->path(), backupDir_ / dir_it->path().filename());
				vFileInfo.push_back(fInfo);
			}
		}
		catch (filesystem_error & ex)
		{
			std::cerr << ex.what() << std::endl;
		}
	}
}

/*
findDestFiles method: to scan destination folder and store values into object that will be
loaded into vector.
*/
void findDestFiles(path backupDir_, vector<FileInfo>& vFileDest)
{
	recursive_directory_iterator dir_it(backupDir_);
	recursive_directory_iterator dir_end;

	for (dir_it; dir_it != dir_end; ++dir_it)
	{
		try
		{
			bool is_copy = true;
			std::regex reg(".(c|cpp|h|hpp)");
			if (regex_match(dir_it->path().extension().string(), reg))
			{
				FileInfo fInfo(dir_it->path().filename().string(), is_copy, file_size(dir_it->path()), dir_it->path(), backupDir_ / dir_it->path().filename());
				vFileDest.push_back(fInfo);
			}
		}
		catch (filesystem_error & ex)
		{
			std::cerr << ex.what() << std::endl;
		}
	}
}

/*
backup method: check the source directory and files are exist
then copy appropriate files from source directory to backup directory
*/
void FileManager::backup() 
{
	// Declare variable
	file_status destDirCheck;
	vector<FileInfo> stringCompare;

	try {
		// Checking if backup directory is already there
		destDirCheck = status(backupDir_);	
	}
	catch (filesystem_error &e)
	{
		cerr << e.what() << endl;
	}

	// Create folder if it is not
	if (is_directory(destDirCheck) == false) {
		create_directories(backupDir_);
	}

	findDestFiles(backupDir_, stringCompare);

	for (vector<FileInfo>::iterator it = vFileInfo.begin(); it != vFileInfo.end(); ++it) {		
		// Check for matches
		for (vector<FileInfo>::iterator it2 = stringCompare.begin(); it2 != stringCompare.end(); ++it2)
		{
			string str1(it->fileName_);
			string str2(it2->fileName_);

			// Compare string file names
			if (str1 == str2)
			{
				// if file name exist, delete it
				remove(path(backupDir_.string() + "\\" + it->fileName_));
			}
		}
	}

	for (vector<FileInfo>::iterator it = vFileInfo.begin(); it != vFileInfo.end(); ++it) {

		// If copy status is true, copy file
		if (it->backupStatus_ == true)
		{
			path src_file = it->sourceDirPath_.string();
			path dest_file = backupDir_.string() + "\\" + it->fileName_;

			// File gets copied
			copy(src_file, dest_file);
		}
	}
}

/*
report method: to report copied file names, file sizes, total count and total file size
*/
void FileManager::report()    
{
	cout << "Root Directory: " << sourceDir_ << endl;
	cout << "Backup Directory: " << backupDir_ << endl;

	unsigned long long totalFileSize = 0;
	char bkStatus;
	unsigned bkTotalCount = 0;

	for (auto x : vFileInfo)
	{
		if (x.backupStatus_) 
		{
			bkStatus = '+';
			totalFileSize += x.fileSize_;
			++bkTotalCount;
		}			
		else 
		{
			bkStatus = '-';
		}
		cout << bkStatus << right << setw(30) << x.fileName_ << "              ";
		cout << "Size: " << x.fileSize_ << endl;		
	}
	cout << "Backup Total:" << right << setw(18) << bkTotalCount << "              ";
	cout << "Size: " << totalFileSize << endl;
}

