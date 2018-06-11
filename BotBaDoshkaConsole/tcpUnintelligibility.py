
# coding: utf-8

# In[13]:


from sklearn.feature_extraction.text import TfidfTransformer, CountVectorizer, TfidfVectorizer
from sklearn.linear_model import LogisticRegression, SGDClassifier
from sklearn.svm import LinearSVC
from sklearn.cross_validation import cross_val_score
from sklearn.pipeline import Pipeline
from sklearn.decomposition import NMF, TruncatedSVD
from sklearn.ensemble import RandomForestClassifier, GradientBoostingClassifier
from sklearn.pipeline import FeatureUnion
from sklearn.externals import joblib
import numpy as np
import pandas as pd
import codecs
import sys
import socket

clf = joblib.load(sys.argv[1])

def predict(string):
    probs = clf.predict_proba([string, string])[0]
    prob = probs[1]/(probs[0]+probs[1])
    return str(prob.round(4)).replace('.',',')

TCP_IP = '127.0.0.1'
TCP_PORT = 5005
BUFFER_SIZE = 500

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.bind((TCP_IP, TCP_PORT))
s.listen(1)

conn, addr = s.accept()

print("Unintelligibility classifier up!")
while True:
    data = conn.recv(BUFFER_SIZE)
    if not data: continue
    f = open(sys.argv[2], mode='w')
    f.write(str(predict(data)))
    f.close()

conn.close()

