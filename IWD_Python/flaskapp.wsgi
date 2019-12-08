#!/usr/bin/python
import sys
import logging
logging.basicConfig(stream=sys.stderr)
sys.path.insert(0,"/usr/games/tictactoe/")

from FlaskApp import app as application
application.secret_key = '1234'