import speech_recognition as sr
from datetime import datetime
import codecs

r = sr.Recognizer()

def write_to_file(value):
    print(value)
    while True:
        dt = datetime.now()
        if dt.second % 2 == 0:
            f = codecs.open('text.txt', 'w', 'utf-8')
            f.write(value)
            f.close()
            print('done')
            return

while True:
    with sr.Microphone() as source:
        print("Скажите что-нибудь")
        audio = r.listen(source)

    try:
        write_to_file(r.recognize_google(audio, language="ru-RU"))
    except sr.UnknownValueError:
        print("Я не расслышала фразу")
    except sr.RequestError as e:
        print("Ошибка сервиса; {0}".format(e))