/*
Module:			FileInfo.hpp
Date:			Sep 29, 2018
Author:			Erica Kim
Description:	A definition of a FileInfo class.
*/

#pragma once

#include <string>
#include <iostream>
#include <regex>
#include <vector>
#include <iomanip>
#include <filesystem>

class FileInfo
{
public:
	std::string fileName_;
	bool backupStatus_;
	unsigned long long fileSize_;
	std::experimental::filesystem::path sourceDirPath_;
	std::experimental::filesystem::path backupDirPath_;

	FileInfo() {};
	FileInfo(std::string fName, bool bStatus, unsigned long long fSize, std::experimental::filesystem::path spath, std::experimental::filesystem::path bpath) :
		fileName_(fName), backupStatus_(bStatus), fileSize_(fSize), sourceDirPath_(spath), backupDirPath_(bpath) {};
};