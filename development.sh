#!/bin/bash

session="dev"

tmux new-session -d -s $session

tmux rename-window -t 1 'nvim'
tmux send-keys -t 'nvim' 'cd Cine.Resenha.UI' C-m 'nvim .' C-m

tmux new-window -t $session:2 -n 'server-front'
tmux new-window -t $session:3 -n 'server-back'
tmux new-window -t $session:4 -n 'terminal'

tmux send-keys -t 'server-back' 'dotnet run --project Cine.Resenha.Api' C-m
tmux send-keys -t 'server-front' 'cd Cine.Resenha.UI' C-m 'npm run dev -- --open' C-m


tmux attach-session -t $session:1
