§
XC:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\IoC\IocConfig.cs
	namespace 	
IoC
 
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

static 
class 
	IocConfig !
{ 
public 
static 
IServiceProvider &
ConfigureService' 7
(7 8
IServiceCollection8 J
servicesK S
)S T
{ 	!
ConfigurarAppServices !
(! "
services" *
)* +
;+ ,
ConfigurarServices 
( 
services '
)' (
;( )
ConfigurarAgents 
( 
services %
)% &
;& '
return 
services 
.  
BuildServiceProvider 0
(0 1
)1 2
;2 3
} 	
private 
static 
void !
ConfigurarAppServices 1
(1 2
IServiceCollection2 D
servicesE M
)M N
{ 	
services 
. 
AddSingleton 
< 
IMensagemAppService 1
,1 2
MensagemAppService3 E
>E F
(F G
)G H
;H I
} 	
private   
static   
void   
ConfigurarServices   .
(  . /
IServiceCollection  / A
services  B J
)  J K
{!! 	
services"" 
.## 
AddSingleton## 
<##  
IConversationService## 2
,##2 3
ConversationService##4 G
>##G H
(##H I
)##I J
.$$ 
AddSingleton$$ 
<$$ 
IWatsonService$$ ,
,$$, -
WatsonService$$. ;
>$$; <
($$< =
)$$= >
;$$> ?
}%% 	
private'' 
static'' 
void'' 
ConfigurarAgents'' ,
('', -
IServiceCollection''- ?
services''@ H
)''H I
{(( 	
services)) 
.** 
AddSingleton** 
<** 
IWatsonAgent** +
,**+ ,
WatsonAgent**- 8
>**8 9
(**9 :
)**: ;
.++ 
AddSingleton++ 
<++ #
IWatsonTokenAccessAgent++ 6
,++6 7"
WatsonTokenAccessAgent++8 N
>++N O
(++O P
)++P Q
;++Q R
},, 	
}-- 
}.. 