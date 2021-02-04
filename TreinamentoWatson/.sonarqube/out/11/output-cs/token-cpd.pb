ô
jC:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\Shared.Util\ApplicationSettings.cs
	namespace 	
Shared
 
. 
Util 
{ 
public 

class 
ApplicationSettings $
:% & 
IApplicationSettings' ;
{ 
private 
readonly !
IConfigurationSection .
_configuracoesApp/ @
;@ A
public

 
ApplicationSettings

 "
(

" #
IConfiguration

# 1
configuracoes

2 ?
)

? @
{ 	
_configuracoesApp 
= 
configuracoes  -
.- .

GetSection. 8
(8 9
$str9 K
)K L
;L M
} 	
public 
string 
UrlBaseWatson #
=>$ &
_configuracoesApp' 8
.8 9
GetValue9 A
<A B
stringB H
>H I
(I J
$strJ Y
)Y Z
;Z [
public 
string 
ApiKeyWatson "
=># %
_configuracoesApp& 7
.7 8
GetValue8 @
<@ A
stringA G
>G H
(H I
$strI W
)W X
;X Y
public 
string 
UrlApiKeyWatson %
=>& (
_configuracoesApp) :
.: ;
GetValue; C
<C D
stringD J
>J K
(K L
$strL ]
)] ^
;^ _
public 
string 
VersaoAssistant %
=>& (
_configuracoesApp) :
.: ;
GetValue; C
<C D
stringD J
>J K
(K L
$strL ]
)] ^
;^ _
public 
string 
WatsonAssistantId '
=>( *
_configuracoesApp+ <
.< =
GetValue= E
<E F
stringF L
>L M
(M N
$strN a
)a b
;b c
public 
string 
WatsonInstanceId &
=>' )
_configuracoesApp* ;
.; <
GetValue< D
<D E
stringE K
>K L
(L M
$strM _
)_ `
;` a
} 
} ò
kC:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\Shared.Util\Constantes\CacheKeys.cs
	namespace 	
Shared
 
. 
Util 
. 

Constantes  
{ 
public 

static 
class 
	CacheKeys !
{ 
public 
const 
string 
AccessTokenWatson -
=. /
$str0 C
;C D
} 
} Ú
gC:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\Shared.Util\Constantes\Rotas.cs
	namespace 	
Shared
 
. 
Util 
. 

Constantes  
{ 
public 

static 
class 
Rotas 
{ 
public 
static 
class 
WatsonAgent '
{ 	
public 
const 
string 
ENVIAR_MENSAGEM  /
=0 1
$str2 n
;n o
} 	
}		 
}

 †
vC:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\Shared.Util\Interfaces\IApplicationSettings.cs
	namespace 	
Shared
 
. 
Util 
. 

Interfaces  
{ 
public 

	interface  
IApplicationSettings )
{ 
string 
UrlBaseWatson 
{ 
get "
;" #
}$ %
string 
ApiKeyWatson 
{ 
get !
;! "
}# $
string 
UrlApiKeyWatson 
{  
get! $
;$ %
}& '
string 
VersaoAssistant 
{  
get! $
;$ %
}& '
string		 
WatsonInstanceId		 
{		  !
get		" %
;		% &
}		' (
string

 
WatsonAssistantId

  
{

! "
get

# &
;

& '
}

( )
} 
} 