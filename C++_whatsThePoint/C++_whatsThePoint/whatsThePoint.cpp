#include <iostream>
#include <string>
using namespace std;
string str = "1";
string* strp = &str;
string strLine = "0123456789";
string* strlp = &strLine;
char charline[] = "0123456789";//���ַ�������charline�������ھ���ָ��
								//�������ַ����ǿɱ�ģ��Ҳ����ݿ��޸ġ�

const char* printLineP = "0123456789";//��������һ���̶��Ĳ��ɱ���ַ������Ҳ����ݲ����޸ģ��������¶���

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
//�޲��޷���ֵ�ĺ���ָ��ʹ��
void chapter6(void (*fun)(void)) {
	cout << "�޲��޷��غ���ָ��" << endl;
	(*fun)();
}
void chapter6_1() {
	cout << "123" << endl;
}
//�в��з���ֵ�ĺ���ָ��
void chapter7(int (*fun)(int)) {
	cout << fun << endl;
	(*fun)(6666);
}
int chapter7_1(int x) {
	cout << x << endl;
	return 0;
}
//�в��޷���ֵ����ָ��
void chapter8(void(*fun)(int)) {
	cout << fun << endl;
	(*fun)(777);
}
void chapter8_1(int x) {
	cout << x << endl;
}
//�޲��з���ֵ����ָ��
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