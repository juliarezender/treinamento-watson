µ
eC:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\Domain\ConversationService.cs
	namespace 	
Domain
 
. 
Modelos 
{ 
public 

class 
ConversationService $
:% & 
IConversationService' ;
{ 
private		 
readonly		 
IWatsonService		 '
_watsonService		( 6
;		6 7
public 
ConversationService "
(" #
IWatsonService# 1
watsonService2 ?
)? @
{ 	
_watsonService 
= 
watsonService *
;* +
} 	
public 
async 
Task 
< 
Mensagem "
>" #"
EnviarMensagemAoWatson$ :
(: ;
Mensagem; C
mensagemD L
)L M
{ 	
var !
mensagemEntradaWatson %
=& '
_watsonService( 6
.6 7#
PreencherMensagemWatson7 N
(N O
mensagemO W
)W X
;X Y
var "
mensagemRespostaWatson &
=' (
await) .
_watsonService/ =
.= >"
EnviarMensagemAoWatson> T
(T U!
mensagemEntradaWatsonU j
)j k
;k l
var 
mensagemResposta  
=! "
new# &
Mensagem' /
(/ 0
mensagem0 8
,8 9"
mensagemRespostaWatson: P
)P Q
;Q R
return 
mensagemResposta #
;# $
} 	
} 
} ß
_C:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\Domain\WatsonService.cs
	namespace

 	
Domain


 
{ 
public 

class 
WatsonService 
:  
IWatsonService! /
{ 
private 
readonly 
IWatsonAgent %
_watsonAgent& 2
;2 3
public 
WatsonService 
( 
IWatsonAgent )
watsonAgent* 5
)5 6
{ 	
_watsonAgent 
= 
watsonAgent &
;& '
} 	
public 
async 
Task 
<  
OutputConversaWatson .
>. /"
EnviarMensagemAoWatson0 F
(F G
InputConversaWatsonG Z
mensagem[ c
)c d
{ 	
try 
{ 
var "
mensagemRespostaWatson *
=+ ,
await- 2
_watsonAgent3 ?
.? @"
EnviarMensagemAoWatson@ V
(V W
mensagemW _
)_ `
;` a
return "
mensagemRespostaWatson -
;- .
} 
catch 
( 
	Exception 
) 
{ 
throw 
; 
} 
}   	
public!! 
InputConversaWatson!! "#
PreencherMensagemWatson!!# :
(!!: ;
Mensagem!!; C
mensagem!!D L
)!!L M
{"" 	
var## 
conversaWatson## 
=##  
new##! $
InputConversaWatson##% 8
{$$ 
Input%% 
=%% 
new%% 
	UserInput%% %
{&& 
Texto'' 
='' 
mensagem'' $
.''$ %
Texto''% *
}(( 
})) 
;)) 
return++ 
conversaWatson++ !
;++! "
},, 	
}-- 
}.. 