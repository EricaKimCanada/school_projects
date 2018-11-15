/*
@file: Project1_Stats.cpp
@author Erica Kim
@date 2018-06-16
@version 0.1
@Project1 : Calculate various statistics
*/
#include <iostream>
#include <vector>
#include <string>
#include <iomanip>
#include <locale>
#include <algorithm>
#include <map>

using namespace std;

//declare prototype of functions
void quickSort(vector<double>& v, int left, int right);
double calcMedian(vector<double>& v);
double calcMean(vector<double>& v);
vector<double> calcMode(vector<double>& v);
vector<double> absDeviation(vector<double>& v, double d);
double calcVariance(vector<double>& v, double dMean);
void calcFrequencyDistribution(vector<double>& v, double dMax, double dMin);
void calcQuintile(vector<double>& v);
void calcOutliers(vector<double>& v, double dMean, double dStandardDev);

int main()
{
	locale here("");
	cout.imbue(here);

	vector<double> v;
	double dValues;
	while (cin >> dValues)
	{
		v.push_back(dValues);
	}

	cout << "Results:" << endl;
	cout << "N = " << v.size() << endl;

	//no data : show error message
	if (v.size() == 0)
	{
		cout << "empty data set!" << endl;
		return 0;
	}

	//sorting data in vector
	quickSort(v,0,v.size() - 1);

	cout << fixed << setprecision(3);
	double dMin = *min_element(v.begin(), v.end());
	double dMax = *max_element(v.begin(), v.end());
	cout << "Min = " << dMin << endl;
	cout << "Max = " << dMax << endl;

	double dMean = calcMean(v);
	double dMedian = calcMedian(v);
	cout << "Arithmetic mean = " << dMean << endl;
	cout << "Statistical median = " << dMedian << endl;

	//calculate mode
	vector<double> vMode = calcMode(v);
	if (vMode.empty())
		cout << "Mode = No mode" << endl;
	else
	{
		cout << "Mode = { ";
		for (size_t i = 0; i < vMode.size(); ++i)
		{
			cout << vMode[i] << ", ";
		}
		//Cursor moves 2 position backwards
		cout << '\b' << '\b';  
		cout << " }" << endl;
	}

	//using absDeviation fn and calcMean fn
	vector<double> vAbsMean = absDeviation(v, dMean);
	double dAbsMean = calcMean(vAbsMean);
	cout << "Mean absolute deviation = " << dAbsMean << endl;

	vector<double> vAbsMedian = absDeviation(v, dMedian);
	double dAbsMedian = calcMean(vAbsMedian);
	cout << "Median absolute deviation = " << dAbsMedian << endl;

	//print the mode data in each case: no mode, unique mode, multi-mode
	if (vMode.empty())
		cout << "Mode absolute deviation = N/A (no unique mode)" << endl;
	else if (vMode.size() >= 2)
		cout << "Mode absolute deviation = N/A (no unique mode)" << endl;
	else
	{
		double dMode = vMode[0];
		vector<double> vAbsMode = absDeviation(v, dMode);
		double dAbsMode = calcMean(vAbsMode);
		cout << "Mode absolute deviation = " << dAbsMode << endl;
	}

	double dVariance = calcVariance(v, dMean);
	cout << "Variance = " << dVariance << endl;

	double dStandardDev = sqrt(dVariance);
	cout << "Standard deviation = " << dStandardDev << endl;
	
	calcFrequencyDistribution(v, dMax, dMin);

	//if the number of data is less than 5 print the warning message
	if (v.size() >= 5)
		calcQuintile(v);
	else
		cout << "\n" << "Quintile means" << "\n" << "\n" << "No quintiles to compute, there are less thatn 5 samples" << endl;
			
	calcOutliers(v, dMean, dStandardDev);

	return 0;
}

/*
@fn void quickSort(vector<double>& v, int low, int high)
@sort data in vector 
@refer Lomuto partition scheme but not use partition
@intergrate algorithm in one function
@param vector, low: the smallest index, high: the biggest index
*/
void quickSort(vector<double>& v, int low, int high)
{
	if (low == high)
		return;

	if (low < high)
	{
		double pivot = v[high];
		int temp = low;  //0

		for (int i = low; i < high; i++)
		{
			if (v[i] <= pivot)
			{
				swap(v[i], v[temp]);
				temp++;
			}
		}
		swap(v[temp], v[high]);
		int newPivot = temp;

		quickSort(v, low, newPivot - 1);
		quickSort(v, newPivot + 1, high);
	}
}

/*
@fn double calcMedian(vector<double>& v)
@calculate median value
@if total number of data (n) is even: mean of vector[n/2-1] + vector[n/2]
@if the number of data (n) is odd:vector[(n+1)/2-1]
@param vector
@return median value
*/
double calcMedian(vector<double>& v)
{
	double dMed = 0.0;
	if (v.size() % 2 == 0)
	{
		dMed = (v[(v.size() / 2) - 1] + v[v.size() / 2]) / 2;
	}
	else
	{
		int index = (v.size() + 1) / 2;
		dMed = v[index-1];
	}
	return dMed;
}

/*
@fn double calcMean(vector<double>& v)
@calculate mean value
@param vector
@return sum divide the number of vector data
*/
double calcMean(vector<double>& v)
{
	double dMean = 0;
	for (auto x : v)
		dMean += x;
	return dMean / v.size();
}

/*
@fn vector<double> calcMode(vector<double>& v)
@calculate mode value using map
@key of map: the value of vector
@value of map: the number of duplicate data in vector
@param vector
@return vector of mode data
*/
vector<double> calcMode(vector<double>& v)
{
	map<double, int> modeMap;
	for (auto key: v)  
	{
		modeMap[key] += 1;
	}

	int temp = 0;
	bool isMode = false;
	map<double, int>::iterator iter;

	//if the values are all same : isMode is false
	//if not isMode is true
	for (iter = modeMap.begin(); iter != modeMap.end(); ++iter) 
	{
		if (iter == modeMap.begin())
			temp = (*iter).second;

		if ((*iter).second == temp) 
		{
			temp = (*iter).second;
		}
		else 
		{
			isMode = true;
		}
	}

	//if the data has mode store the data in the new vector
	int storeValue = 0;
	vector<double> vMode;
	if (isMode)
	{
		//store the biggest data
		for (iter = modeMap.begin(); iter != modeMap.end(); ++iter)
		{
			if (iter == modeMap.begin())
				storeValue = (*iter).second;

			if ((*iter).second > storeValue)
				storeValue = (*iter).second;   
		}

		//add the key of the data in the new vector
		for (iter = modeMap.begin(); iter != modeMap.end(); ++iter)
		{
			if ((*iter).second == storeValue)
				vMode.push_back((*iter).first);
		}
	}
	return vMode;
}

/*
@fn vector<double> absDeviation(vector<double>& v, double d)
@to calculate absolute deviation of mean, median, mode
@each vector data subtract mean, median, mode
@add the absolute data in the new vector
@param vector and mean, median, mode values
@return vector 
*/
vector<double> absDeviation(vector<double>& v, double d)
{
	vector<double> vAbs;
	for (auto it = v.begin(); it != v.end(); ++it)
	{
		vAbs.push_back(fabs(*it - d));
	}
	return vAbs;
}

/*
@fn double calcVariance(vector<double>& v, double dMean)
@to calculate variance
@param vector and mean
@return the sum divede the number of vector data
*/
double calcVariance(vector<double>& v, double dMean)
{
	double sum = 0.0;
	for (auto it = v.begin(); it != v.end(); ++it)
	{
		double dAddDis = (*it - dMean) * (*it - dMean);
		sum += dAddDis;
	}
	return sum / v.size();
}

/*
@fn void calcFrequencyDistribution(vector<double>& v, double dMax, double dMin)
@to calculate Frequency Distribution
@calculate range and interval
@base is min data and add interval. after that add interval repeatedly 
@calculate the frequency of number between interval and ratio 
@param vector and max value, min value of vector data
@print the result to console
*/
void calcFrequencyDistribution(vector<double>& v, double dMax, double dMin)
{
	double range = dMax - dMin; 
	double interval = (range / 10) * 1.00714;    //* 1.01;  //*1.00114;  
	int frequency;
	double percentage;

	double base = dMin;
	cout << fixed << setprecision(2);
	cout << endl;

	//calculate frequency and ratio
	while(base <= dMax)
	{ 
		cout << "[" << setw(7) << base << ".." << setw(7) << base + interval << ")";

		frequency = 0;
		percentage = 0.0;
		for (auto it = v.begin(); it != v.end(); ++it)
		{
			if (*it >= base && *it <= base + interval)
				++frequency;
		}
		percentage = frequency * (1.0 / v.size());
		cout << " = " << setw(3) << frequency << setw(3) << " : " << percentage << endl;
		base += interval;
	}
}

/*
@fn void calcQuintile(vector<double>& v)
@to calculate quintile means (fifth)
@calculate rangeStart and rangeEnd
@add numbers between rangeStart and rangeEnd into the new vector
@reuse calcMean function to calculate mean
@param vector
@print the result to console
*/
void calcQuintile(vector<double>& v)
{
	int rangeStart = 0;
	int rangeEnd = 0;

	cout << endl << "Quintile means" << endl;

	for (int i = 0; i < 5; ++i)
	{
		if (i == 0)
			rangeStart = i;
		else
			rangeStart = (int)(i * (v.size() / 5.0));

		if (i == 4)
			rangeEnd = v.size();
		else
			rangeEnd = (int)((i+1) * (v.size() / 5.0));

		vector<double> vQuintileStore;
		for (int j = rangeStart; j < rangeEnd; ++j)
		{
			vQuintileStore.push_back(v[j]);
		}

		//using calcMean function
		double dQuintileMean = calcMean(vQuintileStore);

		cout << "Q" << i + 1 << ":" << setw(7) << right << dQuintileMean << " ";
		cout << "["<< rangeStart << ".." << rangeEnd << ")" << endl;
	}
}

/*
@fn void calcOutliers(vector<double>& v,double dMean, double dStandardDev)
@to calculate outliers
@four variables: less than 2 and 3 standard deviations and greater than 2 and 3 standard deviations
@param vector, mean, standard deviation data
@print the result to console
*/
void calcOutliers(vector<double>& v,double dMean, double dStandardDev)
{
	int iLower_3SD = 0;
	int iLower_2SD = 0;
	int iUpper_2SD = 0;
	int iUpper_3SD = 0;

	for (auto it = v.begin(); it != v.end(); ++it)
	{
		if (*it < dMean - (3 * dStandardDev))
			++iLower_3SD;

		if (*it < dMean - (2 * dStandardDev))
			++iLower_2SD;

		if (*it > dMean + (2 * dStandardDev))
			++iUpper_2SD;

		if (*it > dMean + (3 * dStandardDev))
			++iUpper_3SD;			
	}

	cout << endl << endl << "Outliers" << endl << "--------" << endl;

	cout << "<= " << "3 dev below: " << iLower_3SD << " (";
	cout << (static_cast<double>(iLower_3SD) / v.size()) * 100 << "%)" << endl;

	cout << "<= " << "2 dev below: " << iLower_2SD << " (";
	cout << (static_cast<double>(iLower_2SD) / v.size()) * 100 << "%)" << endl;

	cout << "<= " << "2 dev above: " << iUpper_2SD << " (";
	cout << (static_cast<double>(iUpper_2SD) / v.size()) * 100 << "%)" << endl;

	cout << "<= " << "3 dev above: " << iUpper_3SD << " (";
	cout << (static_cast<double>(iUpper_3SD) / v.size()) * 100 << "%)" << endl;
}


