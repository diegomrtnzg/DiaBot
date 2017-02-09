# DiaBot

DiaBot es un Bot realizado utilizando el [Microsoft Bot Framework](https://dev.botframework.com/) y analizando los textos de los usuarios con [LUIS](https://www.luis.ai/) que permite, de forma muy simple, controlar el nivel de azúcar para personas diabéticas.

Puedes probarla como aplicación web en el siguiente enlace: http://diabot.azurewebsites.net/

ATENCIÓN: es un concepto de aplicación y en ningun caso puede utilizarse para tratar o controlar la enfermedad de la diabetes.

##Crea tu propio DiaBot
Para poder utilizar tu propio DiaBot, necesitas configurar lo siguiente:
- En [DiabotDialog.cs](https://github.com/diegomrtnzg/DiaBot/blob/master/DiaBot/DiaBot/Dialog/DiabotDialog.cs) necesitas incorporar la información relativa a tu modelo de LUIS.
- En [Web.config](https://github.com/diegomrtnzg/DiaBot/blob/master/DiaBot/DiaBot/Web.config) necesitas incorporar la información relativa a tu aplicación en Microsoft Bot Framework.
