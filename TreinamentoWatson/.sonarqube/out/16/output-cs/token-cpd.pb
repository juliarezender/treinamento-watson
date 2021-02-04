¼
pC:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\Watson\Controllers\MensagemController.cs
	namespace 	
Watson
 
. 
Controllers 
{		 
[

 
ApiController

 
]

 
[ 
Route 

(
 
$str 
) 
] 
[ 
Produces 
( 
$str  
)  !
]! "
[ 
Consumes 
( 
$str  
)  !
]! "
public 

class 
MensagemController #
:$ %
ControllerBase& 4
{ 
private 
readonly 
IMensagemAppService ,
_mensagemAppService- @
;@ A
public 
MensagemController !
(! "
IMensagemAppService" 5
mensagemAppService6 H
)H I
{ 	
_mensagemAppService 
=  !
mensagemAppService" 4
;4 5
} 	
[ 	
HttpPost	 
] 
public 
async 
Task 
< 
ActionResult &
<& '
MensagemSaida' 4
>4 5
>5 6
ProcessarMensagem7 H
(H I
MensagemEntradaI X
mensagemEntradaY h
)h i
{ 	
try 
{ 
if 
( 
! 

ModelState 
.  
IsValid  '
)' (
return 

BadRequest %
(% &
)& '
;' (
return 
await 
_mensagemAppService 0
.0 1"
ProcessarMensagemAsync1 G
(G H
mensagemEntradaH W
)W X
;X Y
} 
catch   
(   
	Exception   
ex   
)    
{!! 
throw"" 
ex"" 
;"" 
}## 
}$$ 	
}%% 
}&& „
YC:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\Watson\Program.cs
	namespace 	
Watson
 
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

static 
class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	
CreateHostBuilder 
( 
args "
)" #
.# $
Build$ )
() *
)* +
.+ ,
Run, /
(/ 0
)0 1
;1 2
} 	
public 
static 
IHostBuilder "
CreateHostBuilder# 4
(4 5
string5 ;
[; <
]< =
args> B
)B C
=>D F
Host 
.  
CreateDefaultBuilder %
(% &
args& *
)* +
. $
ConfigureWebHostDefaults )
() *

webBuilder* 4
=>5 7
{ 

webBuilder 
. 

UseStartup )
<) *
Startup* 1
>1 2
(2 3
)3 4
;4 5
} 
) 
; 
} 
} Ä&
YC:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\Watson\Startup.cs
	namespace 	
Watson
 
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

class 
Startup 
{ 
public 
Startup 
( 
IConfiguration %
configuration& 3
)3 4
{ 	
Configuration 
= 
configuration )
;) *"
_configuracaoAplicacao "
=# $
new% (
ApplicationSettings) <
(< =
Configuration= J
)J K
;K L
} 	
public 
IConfiguration 
Configuration +
{, -
get. 1
;1 2
}3 4
private 
readonly 
ApplicationSettings ,"
_configuracaoAplicacao- C
;C D
public 
void 
ConfigureServices %
(% &
IServiceCollection& 8
services9 A
)A B
{ 	
services 
. 
AddSingleton !
<! " 
IApplicationSettings" 6
>6 7
(7 8"
_configuracaoAplicacao8 N
)N O
;O P
	IocConfig 
. 
ConfigureService &
(& '
services' /
)/ 0
;0 1
ConfiguracoesCache   
(   
services   '
)  ' (
;  ( )#
ConfiguracoesAutoMapper!! #
(!!# $
services!!$ ,
)!!, -
;!!- .
services$$ 
.$$ 
AddControllers$$ #
($$# $
)$$$ %
;$$% &
services%% 
.%% 
AddSwaggerGen%% "
(%%" #
options%%# *
=>%%+ -
{&& 
options'' 
.'' 

SwaggerDoc'' "
(''" #
$str''# '
,''' (
new'') ,
	Microsoft''- 6
.''6 7
OpenApi''7 >
.''> ?
Models''? E
.''E F
OpenApiInfo''F Q
{(( 
Title)) 
=)) 
$str)) '
,))' (
Version** 
=** 
$str** "
,**" #
Description++ 
=++  !
$str++" *
,++* +
},, 
),, 
;,, 
}-- 
)-- 
;-- 
services.. 
... 
AddMemoryCache.. #
(..# $
)..$ %
;..% &
}00 	
public33 
void33 
	Configure33 
(33 
IApplicationBuilder33 1
app332 5
,335 6
IWebHostEnvironment337 J
env33K N
)33N O
{44 	
if66 
(66 
env66 
.66 
IsDevelopment66 !
(66! "
)66" #
)66# $
{77 
app88 
.88 %
UseDeveloperExceptionPage88 -
(88- .
)88. /
;88/ 0
}99 
app;; 
.;; 
UseHttpsRedirection;; #
(;;# $
);;$ %
;;;% &
app== 
.== 

UseRouting== 
(== 
)== 
;== 
app?? 
.?? 
UseAuthorization??  
(??  !
)??! "
;??" #
appAA 
.AA 
UseEndpointsAA 
(AA 
	endpointsAA &
=>AA' )
{BB 
	endpointsCC 
.CC 
MapControllersCC (
(CC( )
)CC) *
;CC* +
}DD 
)DD 
;DD 
appFF 
.FF 

UseSwaggerFF 
(FF 
)FF 
;FF 
appGG 
.GG 
UseSwaggerUIGG 
(GG 
optionsGG $
=>GG% '
optionsGG( /
.GG/ 0
SwaggerEndpointGG0 ?
(GG? @
$strGG@ Z
,GGZ [
$strGG\ p
)GGp q
)GGq r
;GGr s
}HH 	
privateJJ 
staticJJ 
voidJJ #
ConfiguracoesAutoMapperJJ 3
(JJ3 4
IServiceCollectionJJ4 F
servicesJJG O
)JJO P
{KK 	
servicesLL 
.LL 
AddAutoMapperLL "
(LL" #
	AppDomainLL# ,
.LL, -
CurrentDomainLL- :
.LL: ;
GetAssembliesLL; H
(LLH I
)LLI J
)LLJ K
;LLK L
}MM 	
privateOO 
staticOO 
voidOO 
ConfiguracoesCacheOO .
(OO. /
IServiceCollectionOO/ A
servicesOOB J
)OOJ K
{PP 	
servicesQQ 
.QQ %
AddDistributedMemoryCacheQQ .
(QQ. /
)QQ/ 0
;QQ0 1
}RR 	
}SS 
}TT 