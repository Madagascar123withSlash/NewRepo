import cv2 
import numpy as np 
from matplotlib import pyplot as plt 
# 读取图像并转换为灰度图像 
img = cv2.imread('C:/Users/Thinkpad/Desktop/jppkjwpj.png', cv2.IMREAD_GRAYSCALE)
# 进行傅里叶变换 
f = np.fft.fft2(img) 
fshift = np.fft.fftshift(f)  
# 计算图像的幅度谱和相位谱 
magnitude_spectrum = 20 * np.log(np.abs(fshift)) 
phase_spectrum = np.angle(fshift) #相位谱没有用到
# 计算MTF曲线 
rows, cols = img.shape 
crow, ccol = rows // 2, cols // 2 
# 按照距离计算点的位置 
x = np.linspace(-cols / 2, cols / 2 - 1, cols) 
y = np.linspace(-rows / 2, rows / 2 - 1, rows) 
X, Y = np.meshgrid(x, y) 
D = np.sqrt(X**2 + Y**2) 
# 计算径向平均值 
bin_width = 5 
bins = np.arange(0, int(np.ceil(np.max(D))) + bin_width, bin_width) 
digitized = np.digitize(D.flat, bins) 
mtf = [] 
for i in range(1, len(bins)): 
    indices = np.where(digitized == i) 
    if len(indices[0]) > 0: 
        mtf.append(np.mean(magnitude_spectrum.flat[indices])) 
    else: mtf.append(0) 
# 绘制MTF曲线 
mtf = np.array(mtf) / np.max(mtf) 
plt.plot(bins[:-1], mtf) 
plt.xlabel('Spatial Frequency (cy/mm)') 
plt.ylabel('Contrast') 
plt.title('MTF') 
plt.show()