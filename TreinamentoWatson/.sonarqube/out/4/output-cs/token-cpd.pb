¨
tC:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\TreinamentoWatson\Interfaces\IWatsonAgent.cs
	namespace 	
TreinamentoWatson
 
. 

Interfaces &
{ 
public 

	interface 
IWatsonAgent !
{ 
Task		 
<		  
OutputConversaWatson		 !
>		! ""
EnviarMensagemAoWatson		# 9
(		9 :
InputConversaWatson		: M
mensagem		N V
)		V W
;		W X
}

 
} í
C:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\TreinamentoWatson\Interfaces\IWatsonTokenAccessAgent.cs
	namespace 	
TreinamentoWatson
 
. 

Interfaces &
{ 
public 

	interface #
IWatsonTokenAccessAgent ,
{ 
Task 
< 
string 
> 

ObterToken 
(  
)  !
;! "
}		 
}

 š
oC:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\TreinamentoWatson\Watson\WatsonAgent.cs
	namespace 	
TreinamentoWatson
 
. 
Watson "
{ 
public 

class 
WatsonAgent 
: 
IWatsonAgent +
{ 
private 
readonly #
IWatsonTokenAccessAgent 0'
_tokenIntegracaoWatsonAgent1 L
;L M
private 
readonly  
IApplicationSettings -
_config. 5
;5 6
public 
WatsonAgent 
( #
IWatsonTokenAccessAgent #&
tokenIntegracaoWatsonAgent$ >
,> ? 
IApplicationSettings  
config! '
) 	
{ 	'
_tokenIntegracaoWatsonAgent '
=( )&
tokenIntegracaoWatsonAgent* D
;D E
_config 
= 
config 
; 
} 	
public 
async 
Task 
<  
OutputConversaWatson .
>. /"
EnviarMensagemAoWatson0 F
(F G
InputConversaWatsonG Z
mensagem[ c
)c d
{ 	
var 
token 
= 
await '
_tokenIntegracaoWatsonAgent 9
.9 :

ObterToken: D
(D E
)E F
;F G
return 
await 
Policy 
. 
Handle 
< 
FlurlHttpException .
>. /
(/ 0
)0 1
.   

RetryAsync   
(    
)    !
.!! 
ExecuteAsync!! !
(!!! "
(!!" #
)!!# $
=>!!% '
string"" "
.""" #
Format""# )
("") *
_config""* 1
.""1 2
UrlBaseWatson""2 ?
,""? @
_config""A H
.""H I
WatsonInstanceId""I Y
)""Y Z
.## 
AppendPathSegment## .
(##. /
	ObterPath##/ 8
(##8 9
)##9 :
)##: ;
.$$ 
SetQueryParam$$ *
($$* +
$str$$+ 4
,$$4 5
_config$$6 =
.$$= >
VersaoAssistant$$> M
)$$M N
.%%  
WithOAuthBearerToken%% 1
(%%1 2
token%%2 7
)%%7 8
.&& 
PostJsonAsync&& *
(&&* +
mensagem&&+ 3
)&&3 4
.'' 
ReceiveJson'' (
<''( ) 
OutputConversaWatson'') =
>''= >
(''> ?
)''? @
)(( 
;(( 
})) 	
private-- 
string-- 
	ObterPath--  
(--  !
)--! "
{.. 	
return// 
string// 
.// 
Format//  
(//  !
Rotas00 
.00 
WatsonAgent00 !
.00! "
ENVIAR_MENSAGEM00" 1
)11 
;11 
}22 	
}55 
}88 Á 
zC:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\TreinamentoWatson\Watson\WatsonTokenAccessAgent.cs
	namespace 	
TreinamentoWatson
 
. 
Watson "
{ 
public 

class "
WatsonTokenAccessAgent '
:( )#
IWatsonTokenAccessAgent* A
{ 
private 
readonly  
IApplicationSettings -
_config. 5
;5 6
private 
readonly 
IMemoryCache %
_memoryCache& 2
;2 3
private 
const 
double (
fracaoTempoMaximoDeVidaToken 9
=: ;
$num< ?
;? @
public "
WatsonTokenAccessAgent %
(% & 
IApplicationSettings& :
config; A
,A B
IMemoryCacheC O
memoryCacheP [
)[ \
{ 	
_config 
= 
config 
; 
_memoryCache 
= 
memoryCache &
;& '
} 	
public 
Task 
< 
string 
> 

ObterToken &
(& '
)' (
{ 	
if 
( 
_memoryCache 
. 
TryGetValue (
(( )
	CacheKeys) 2
.2 3
AccessTokenWatson3 D
,D E
outF I
AutenticacaoWatsonJ \
token] b
)b c
)c d
{ 
var 
expiracaoLimite #
=$ %
token& +
.+ ,

Expiration, 6
-7 8
(9 :
(: ;
$num; <
-= >(
fracaoTempoMaximoDeVidaToken? [
)[ \
*] ^
token_ d
.d e
	ExpiresIne n
)n o
;o p
if!! 
(!! 
DateTimeOffset!! "
.!!" #
UtcNow!!# )
.!!) *
ToUnixTimeSeconds!!* ;
(!!; <
)!!< =
>=!!> @
expiracaoLimite!!A P
)!!P Q
{"" 
return## 

GerarToken## %
(##% &
)##& '
;##' (
}$$ 
else%% 
{&& 
return'' 
Task'' 
.''  

FromResult''  *
(''* +
token''+ 0
.''0 1
AccessToken''1 <
)''< =
;''= >
}(( 
})) 
return++ 

GerarToken++ 
(++ 
)++ 
;++  
},, 	
private.. 
async.. 
Task.. 
<.. 
string.. !
>..! "

GerarToken..# -
(..- .
)... /
{// 	
var00 
token00 
=00 
await00 
Policy00 $
.11 
Handle11 
<11 
FlurlHttpException11 *
>11* +
(11+ ,
)11, -
.22 

RetryAsync22 
(22 
)22 
.33 
ExecuteAsync33 
(33 
(33 
)33  
=>33! #
_config44 
.44  
UrlApiKeyWatson44  /
.55 

WithHeader55 #
(55# $
$str55$ ,
,55, -
$str55. @
)55@ A
.66 
PostUrlEncodedAsync66 ,
(66, -
new66- 0
{77 

grant_type88 &
=88' (
$str88) Q
,88Q R
apikey99 "
=99# $
_config99% ,
.99, -
ApiKeyWatson99- 9
}:: 
):: 
.;; 
ReceiveJson;; $
<;;$ %
AutenticacaoWatson;;% 7
>;;7 8
(;;8 9
);;9 :
)<< 
;<< 
return>> 
_memoryCache>> 
.>>  
Set>>  #
(>># $
	CacheKeys>>$ -
.>>- .
AccessTokenWatson>>. ?
,>>? @
token>>A F
)>>F G
.>>G H
AccessToken>>H S
;>>S T
}?? 	
}@@ 
}AA 