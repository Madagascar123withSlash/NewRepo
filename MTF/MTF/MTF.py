from argparse import MetavarTypeHelpFormatter
import numpy as np
import cv2
import matplotlib.pyplot as plt


img = cv2.imread('C:/Users/Thinkpad/Desktop/test.jpg', cv2.IMREAD_GRAYSCALE) # 计算图像梯度 
dx = cv2.Sobel(img, cv2.CV_64F, 1, 0, ksize=3) 
dy = cv2.Sobel(img, cv2.CV_64F, 0, 1, ksize=3) 
grad = cv2.magnitude(dx, dy) # 计算SFR曲线 
sfr = [] 
for f in range(0, 30, 1): 
    freq = f / 10.0 
    kernel = np.sin(np.pi * freq * np.arange(-5, 6)) / (np.pi * freq * np.arange(-5, 6)) 
    kernel[5] = 1 - 2 * freq 
    row = np.convolve(grad[grad.shape[0]//2, :], kernel, mode='same') 
    col = np.convolve(grad[:, grad.shape[1]//2], kernel, mode='same') 
    sfr.append(max(row.max(), col.max())) 

plt.plot(sfr)
plt.show()




gray_img = cv2.imread("C:/Users/Thinkpad/Desktop/jppkjwpj.png",0)
f = np.fft.fft2(gray_img)
fshift = np.fft.fftshift(f)

magnitude_spectrum = 20*np.log(np.abs(fshift))
# 计算幅度谱归一化到[0,1]范围内
mag_normalized = magnitude_spectrum / np.max(magnitude_spectrum)
# 计算MTF曲线，以像素为单位
rows, cols = gray_img.shape
x_axis = np.linspace(-cols/2, cols/2-1, cols)   # 横坐标，以毫米为单位
y_axis = []
for i in range(cols):
    y_axis.append(np.sum(mag_normalized[int(rows/2), i:]) / np.sum(mag_normalized[int(rows/2), :]))

plt.plot(x_axis,y_axis)
plt.title("MTF_table")
plt.xlabel("lw/ph")
plt.ylabel("MTF")
plt.show()






