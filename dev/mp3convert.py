"""
This script generates a C header file containing audio values sourced from a WAV file.
"""

import librosa
import pathlib
import numpy as np
import sounddevice as sd
import matplotlib.pyplot as plt
import scipy.io.wavfile
import scipy.signal


def get_resampled_quantized(ys: np.ndarray, sample_rate: float, new_sample_rate: int):

    # bandpass filter
    freq_low = 150
    freq_high = new_sample_rate/2
    sos = scipy.signal.butter(6, [freq_low, freq_high],
                              'bandpass', fs=sample_rate, output='sos')
    ys = scipy.signal.sosfilt(sos, ys)

    # resample
    new_count = int(len(ys) * new_sample_rate / sample_rate)
    xs_new = np.arange(new_count) / new_sample_rate
    xs = np.arange(len(ys)) / sample_rate
    ys = np.interp(xs_new, xs, ys)

    # scale [0, 255]
    ys = ys / max(abs(min(ys)), abs(max(ys)))
    ys = ys / 2 + .5
    ys = ys * 255
    assert min(ys) >= 0
    assert max(ys) <= 255

    # quantize
    ys = ys.astype(np.int16)

    # trim zeros
    zero_value = 127
    for i1 in range(len(ys)):
        if ys[i1] != zero_value:
            break
    for i2 in range(len(ys) - 1, 0, -1):
        if ys[i2] != zero_value:
            break
    ys = ys[i1:i2]

    # ensure accuracy
    assert min(ys) >= 0
    assert max(ys) <= 255

    return ys.astype(np.int8)


def play_quantized_audio(ys, sample_rate):
    ys = ys.astype(np.float32)
    ys = ys - 127
    ys = ys * 256
    ys = ys.astype(np.int16)
    sd.default.samplerate = sample_rate
    sd.play(ys, blocking=True)
    scipy.io.wavfile.write("song2.wav", sample_rate, ys)


if __name__ == "__main__":
    new_sample_rate = 8000
    wav_path = R"C:\Users\scott\Downloads\guardian.wav"
    sample_rate, ys = scipy.io.wavfile.read(wav_path)
    ys = get_resampled_quantized(ys, sample_rate, new_sample_rate)
    print(f"size: {len(ys):,} bytes")
    pathlib.Path("song.bin").write_bytes(ys)