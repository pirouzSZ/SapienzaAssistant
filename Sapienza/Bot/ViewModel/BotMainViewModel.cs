﻿using Sapienza.Bot.Framework;
using Sapienza.Bot.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sapienza.Bot.ViewModel
{
	public class BotMainViewModel : INotifyPropertyChanged
    {
        private MainModel _model = new MainModel();

        public BotMainViewModel()
        {
            Messages = new ObservableCollection<Message>();
        }

        public ObservableCollection<Message> Messages { get; set; }

        private string _text = string.Empty;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        public async Task StartConversation()
        {
            await _model.EnsureConversationEstablished();
        }

        public Command SendCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Messages.Add(new Message()
                    {
                        DateTime = DateTime.Now,
                        Text = Text,
                        MessageType = MessageType.Sent
                    });

                    var receivedMessage = await _model.SendMessage(Text);

                    Messages.Add(receivedMessage);

                    Text = string.Empty;
                });
            }
        }
    }
}
