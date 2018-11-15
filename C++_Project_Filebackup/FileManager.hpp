/*
Module:			FileManager.hpp
Date:			Sep 29, 2018
Author:			Erica Kim
Description:	A definition of a FileManager class.
*/

#pragma once

#include <string>
#include <iostream>
#include <regex>
#include <vector>
#include <iomanip>
#include <filesystem>
#include "FileInfo.hpp"

class FileManager
{
private:
	std::experimental::filesystem::path sourceDir_;
	std::experimental::filesystem::path backupDir_;

public:
	std::vector<FileInfo> vFileInfo;

	//default constructor
	FileManager();

	//1-arg constructor
	FileManager(std::experimental::filesystem::path s_dir);

	//2-arg constructor
	FileManager(std::experimental::filesystem::path s_dir, std::experimental::filesystem::path b_dir);
	
	//copy constructor
	FileManager(FileManager const&);

	//copy assignment operator
	FileManager& operator = (FileManager const&);

	//move constructor - not allowed
	FileManager(FileManager &&) = delete; 

	//move assignment operator - not allowed	
	FileManager& operator = (FileManager &&) = delete;

	void find();

	void backup();  

	void report(); 
};


