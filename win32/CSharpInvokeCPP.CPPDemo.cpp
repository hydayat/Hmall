
#include "pch.h"

#include <opencv2/opencv.hpp>  
#include <opencv2/highgui/highgui.hpp>
#include <opencv2/imgproc/imgproc.hpp>
#include <iostream>  
using namespace cv;
extern "C" __declspec(dllexport) void erode(char* path)
{
	Mat src = imread(path);
	Mat element = getStructuringElement(MORPH_RECT, Size(15, 15));//返回内核矩阵
	Mat dstImage;
	erode(src, dstImage, element);//腐蚀操作
	char drive[100];
	char dir[100];
	char fname[100];
	char ext[100];

	_splitpath(path, drive, dir, fname, ext);

	strcat(fname, "_1");
	_makepath(path, drive, dir, fname, ext);
	imwrite(path, dstImage);
}
extern "C" __declspec(dllexport) void blur(char* path)
{
	Mat src = imread(path);
	Mat dstImage;
	blur(src, dstImage, Size(7, 7));//模糊操作
	char drive[100];
	char dir[100];
	char fname[100];
	char ext[100];

	_splitpath(path, drive, dir, fname, ext);

	strcat(fname, "_2");
	_makepath(path, drive, dir, fname, ext);
	imwrite(path, dstImage);
}
extern "C" __declspec(dllexport) void edge(char* path)
{
	Mat src = imread(path);
	//显示该窗口
	Mat dstImage, edge, grayImage;
	dstImage.create(src.size(), src.type());
	cvtColor(src, grayImage, COLOR_BGR2GRAY);
	blur(grayImage, edge, Size(3, 3));
	Canny(edge, edge, 3, 9, 3);
	char drive[100];
	char dir[100];
	char fname[100];
	char ext[100];

	_splitpath(path, drive, dir, fname, ext);

	strcat(fname, "_3");
	_makepath(path, drive, dir, fname, ext);
	imwrite(path, edge);
}

