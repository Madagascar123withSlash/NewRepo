#include <iostream>
#include <string>
using namespace std;
string str = "1";
string* strp = &str;
string strLine = "0123456789";
string* strlp = &strLine;
char charline[] = "0123456789";//在字符数组下charline单独存在就是指针
								//声明的字符串是可变的，右侧内容可修改、

const char* printLineP = "0123456789";//用于声明一个固定的不可变的字符串，右侧内容不可修改，但可重新定向

void print(const char* str) {
	printf("%s\n", str);
}


void chapter1(string str) {
	str = str + "2";
	cout << "chapterOne" << str << endl;
}

void chapter2(string* strp) {

	*strp =*strp + "2";
	cout << "chapterTwo" << str << endl;

}

void chapter3(string* strlp) {
	string substring = *strlp;
	cout << "chapterThree:" << strlp+1 << endl;
	cout << sizeof(strlp) << endl;
}
void chapter4(string strl) {
	string substring;
	substring = strl[2];
	cout << "chapterFour:" << substring << endl;
}
void chapter5(char* ch) {
	char getstr[10];
	for (int i = 0; i < 4; i++)
	{
		getstr[i] = *(ch + 3 + i);
	}
	getstr[4] = '\0';
	cout << "chapterFive:" << ch << endl;
	cout << getstr << endl;
}
//无参无返回值的函数指针使用
void chapter6(void (*fun)(void)) {
	cout << "无参无返回函数指针" << endl;
	(*fun)();
}
void chapter6_1() {
	cout << "123" << endl;
}
//有参有返回值的函数指针
void chapter7(int (*fun)(int)) {
	cout << fun << endl;
	(*fun)(6666);
}
int chapter7_1(int x) {
	cout << x << endl;
	return 0;
}
//有参无返回值函数指针
void chapter8(void(*fun)(int)) {
	cout << fun << endl;
	(*fun)(777);
}
void chapter8_1(int x) {
	cout << x << endl;
}
//无参有返回值函数指针
void chapter9(int (*fun)(void)) {
	(*fun)();
}
int chapter9_1() {
	cout << 888 << endl;
	return 0;
}

int main() {
	print(printLineP);
	chapter9(chapter9_1);
	cout << "result" << str << endl;
	return 0;
}