'''stereo2mono-R.py
convert stereo to mono recursively
usage : python stereo2mono-R.py path-directory
'''

import os, sys

from stereo2mono import *

directory = sys.argv[1]
os.chdir(directory)

for name in os.listdir('.'):
    if name.endswith('.wav'):
        w = Stereo2Mono(name)
        if w.isStereo() == 1:
            print('%s is in stereo'%name)
            print('Check for %s samples in the audio frame'%SAMPLING)
            w.CompareSampling()
            print('Both channels seem to be identical')
            print('Check all data frames and save to mono file')
            w.CompareAndSave()
            print('Done')
        else:
            print('%s is already in mono'%name)
    else:
        pass
