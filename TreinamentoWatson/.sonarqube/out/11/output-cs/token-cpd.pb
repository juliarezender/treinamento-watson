¤
tC:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\AppService\Interfaces\IMensagemAppService.cs
	namespace 	

AppService
 
. 

Interfaces 
{ 
public 

	interface 
IMensagemAppService (
{ 
Task		 
<		 
MensagemSaida		 
>		 "
ProcessarMensagemAsync		 2
(		2 3
MensagemEntrada		3 B
mensagemEntrada		C R
)		R S
;		S T
}

 
} ÿ
hC:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\AppService\MensagemAppService.cs
	namespace 	

AppService
 
{ 
public		 

class		 
MensagemAppService		 #
:		$ %
IMensagemAppService		& 9
{

 
private 
readonly  
IConversationService - 
_conversationService. B
;B C
public 
MensagemAppService !
(! " 
IConversationService" 6
conversationService7 J
)J K
{ 	 
_conversationService  
=! "
conversationService# 6
;6 7
} 	
public 
async 
Task 
< 
MensagemSaida '
>' ("
ProcessarMensagemAsync) ?
(? @
MensagemEntrada@ O
mensagemEntradaP _
)_ `
{ 	
var 
mensagem 
= 
new 
Mensagem '
(' (
mensagemEntrada( 7
)7 8
;8 9
var 
mensagemResposta  
=! "
await# ( 
_conversationService) =
.= >"
EnviarMensagemAoWatson> T
(T U
mensagemU ]
)] ^
;^ _
return 
new 
MensagemSaida $
($ %
mensagemResposta% 5
)5 6
;6 7
} 	
} 
} 