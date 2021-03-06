﻿using System;
using System.ComponentModel;
using ImageServiceGUI.Communication;
using ImageService.Infrastructure.Enums;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace ImageServiceGUI.Model
{
    class SettingsModel : ISettingsModel
    {
        public ICommunicationSingleton communication;

        public SettingsModel()
        {
            this.LbHandlers = new ObservableCollection<string>();
            this.communication = CommunicationSingleton.Instance;
            this.communication.InMessage += IncomingMessage;
            this.communication.Read();
        }

        private void IncomingMessage(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.Command == (int)CommandEnum.GetConfigCommand)
                {
                    this.OutputDirectory = e.Args[0];
                    this.SourceName = e.Args[1];
                    this.LogName = e.Args[2];
                    this.TumbnailSize = e.Args[3];
                    string[] handlers = e.Args[4].Split(';');
                    foreach (string handler in handlers)
                    {
                        this.LbHandlers.Add(handler);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private string logName;
        public string LogName
        {
            get { return logName; }
            set
            {
                if (this.logName != value)
                {
                    this.logName = value;
                    this.NotifyPropertyChanged("LogName");
                }
            }
        }
        private string outputDirectory;
        public string OutputDirectory
        {
            get { return outputDirectory; }
            set
            {
                if (this.outputDirectory != value)
                {
                    this.outputDirectory = value;
                    this.NotifyPropertyChanged("OutputDirectory");
                }
            }
        }
        private string sourceName;
        public string SourceName
        {
            get { return sourceName; }
            set
            {
                if (this.sourceName != value)
                {
                    this.sourceName = value;
                    this.NotifyPropertyChanged("SourceName");
                }
            }
        }
        private string thumbnailSize;
        public string TumbnailSize
        {
            get { return thumbnailSize; }
            set
            {
                if (this.thumbnailSize != value)
                {
                    this.thumbnailSize = value;
                    this.NotifyPropertyChanged("ThumbnailSize");
                }
            }
        }

        public ObservableCollection<string> LbHandlers { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}