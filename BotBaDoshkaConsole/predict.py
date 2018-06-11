
# coding: utf-8

# In[2]:


from sklearn.neural_network import MLPClassifier
import codecs
import numpy as np
from sklearn.externals import joblib
import sys

neuralclf = joblib.load(sys.argv[1])
listInput = [float(i) for i in sys.argv[2].split(",")]
prediction = neuralclf.predict([listInput, listInput])[0]

f = open(sys.argv[3], mode='w')
f.write(str(prediction))
f.close()

