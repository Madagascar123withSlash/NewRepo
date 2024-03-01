import cv2
import psutil


sample = cv2.imread("sample.BMP",cv2.IMREAD_GRAYSCALE)
origin = cv2.imread("origin_4.BMP")
origin_gray = cv2.cvtColor(origin,cv2.COLOR_BGR2GRAY)
result = cv2.matchTemplate(origin_gray,sample,cv2.TM_SQDIFF_NORMED)
minVal,maxVal,minLoc,maxLoc = cv2.minMaxLoc(result)
w,h = sample.shape[::]
topleft = minLoc
bottomRight = (topleft[0]+w,topleft[1]+h)
cv2.rectangle(origin,topleft,bottomRight,(0,0,255),2)
print("匹配得分:{}".format(str(minVal)))
cv2.imshow("123",origin)
cv2.waitKey(0)

