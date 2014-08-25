using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace MashBesh
{
    [Serializable]
    class Settings
    {
        public bool soundIn, musicIn;
        const int defaultMusicVolume = 100;
        int musicVolume;
        public int MusicVolume
        {
            get { return musicVolume; }
            set { if ((value >= 0) & (value <= 100)) { musicVolume = value; } else { musicVolume = defaultMusicVolume; } }
        }
        public string backGroundMusicLocation;
        public string rollADieSoundLocation;
        public string soundMoveLocation;
        public string mainMenuBackgroundMusicLocation;

        public Settings()
        {
            SetDefaultValues();
        }

        public void SetDefaultValues()
        {
            soundIn = true;
            musicIn = true;
            musicVolume = defaultMusicVolume;
            backGroundMusicLocation = @"Audio\mainTheme.wav";
            rollADieSoundLocation = @"Audio\rollADice.wav";
            soundMoveLocation = @"Audio\move.wav";
            mainMenuBackgroundMusicLocation = @"Audio\mainMenuTheme.wav";
        }

        public void Load()
        {
            Settings configuration = new Settings();
            try
            {
                FileStream savingStream = new FileStream("Settings.bin", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                configuration = (Settings)bf.Deserialize(savingStream);
                savingStream.Close();
                soundIn = configuration.soundIn;
                musicIn = configuration.musicIn;
                MusicVolume = configuration.MusicVolume;
                backGroundMusicLocation = configuration.backGroundMusicLocation;
                rollADieSoundLocation = configuration.rollADieSoundLocation;
                soundMoveLocation = configuration.soundMoveLocation;
                mainMenuBackgroundMusicLocation = configuration.mainMenuBackgroundMusicLocation;
            }
            catch
            {
                MessageBox.Show("Файл Settings.bin не найден или поврежден. Будут восстановлены стандартные настройки");
                SetDefaultValues();
                Save();
            }
        }

        public void Save()
        {
            Settings configuration = new Settings();
            try
            {
                FileStream savingStream = new FileStream("Settings.bin", FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                configuration.MusicVolume = musicVolume;
                configuration.musicIn = musicIn;
                configuration.soundIn = soundIn;
                configuration.backGroundMusicLocation = backGroundMusicLocation;
                configuration.mainMenuBackgroundMusicLocation = mainMenuBackgroundMusicLocation;
                configuration.soundMoveLocation = soundMoveLocation;
                configuration.rollADieSoundLocation = rollADieSoundLocation;
                bf.Serialize(savingStream, configuration);
                savingStream.Close();
            }
            catch (Exception excep) { MessageBox.Show(excep.Message); }

        }
    }
}
