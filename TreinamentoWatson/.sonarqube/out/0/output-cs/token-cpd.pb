Í
iC:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\Domain.Modelos\MensagemEntrada.cs
	namespace 	
Domain
 
. 
Modelos 
{ 
public 

class 
MensagemEntrada  
{ 
public 
string 
Texto 
{ 
get !
;! "
set# &
;& '
}( )
} 
} Ÿ
gC:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\Domain.Modelos\MensagemSaida.cs
	namespace 	
Domain
 
. 
Modelos 
. 
Watson 
{ 
public 

class 
MensagemSaida 
{ 
public 
List 
< 
string 
> 
Textos "
{# $
get% (
;( )
set* -
;- .
}/ 0
public		 
MensagemSaida		 
(		 
Mensagem		 %
mensagem		& .
)		. /
{

 	
Textos 
= 
mensagem 
. 
Textos $
;$ %
} 	
} 
} ÿ
sC:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\Domain.Modelos\Watson\AutenticacaoWatson.cs
	namespace 	
Domain
 
. 
Modelos 
. 
Watson 
{ 
public 

class 
AutenticacaoWatson #
{ 
[ 	
JsonProperty	 
( 
$str $
)$ %
]% &
public 
string 
AccessToken !
{" #
get$ '
;' (
set) ,
;, -
}. /
[

 	
JsonProperty

	 
(

 
$str

 %
)

% &
]

& '
public 
string 
RefreshToken "
{# $
get% (
;( )
set* -
;- .
}/ 0
[ 	
JsonProperty	 
( 
$str "
)" #
]# $
public 
string 
	TokenType 
{  !
get" %
;% &
set' *
;* +
}, -
[ 	
JsonProperty	 
( 
$str "
)" #
]# $
public 
int 
	ExpiresIn 
{ 
get "
;" #
set$ '
;' (
}) *
[ 	
JsonProperty	 
( 
$str "
)" #
]# $
public 
long 

Expiration 
{  
get! $
;$ %
set& )
;) *
}+ ,
[ 	
JsonProperty	 
( 
$str 
) 
] 
public 
string 
Scope 
{ 
get !
;! "
set# &
;& '
}( )
} 
} Ð
hC:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\Domain.Modelos\Watson\Generic.cs
	namespace 	
Domain
 
. 
Modelos 
. 
Watson 
{ 
public 

class 
Generic 
{ 
[ 	
JsonProperty	 
( 
$str 
, 
NullValueHandling /
=0 1
NullValueHandling2 C
.C D
IncludeD K
)K L
]L M
public 
string 
Textos 
{ 
get "
;" #
set$ '
;' (
}) *
}		 
}

 Æ
tC:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\Domain.Modelos\Watson\InputConversaWatson.cs
	namespace 	
Domain
 
. 
Modelos 
{ 
public 

class 
InputConversaWatson $
{ 
[ 	
JsonProperty	 
( 
$str 
, 
NullValueHandling 0
=1 2
NullValueHandling3 D
.D E
IgnoreE K
)K L
]L M
public		 
	UserInput		 
Input		 
{		  
get		! $
;		$ %
set		& )
;		) *
}		+ ,
}

 
} £
iC:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\Domain.Modelos\Watson\Mensagem.cs
	namespace 	
Domain
 
. 
Modelos 
. 
Watson 
{ 
public 

class 
Mensagem 
{ 
public 
string 
Texto 
{ 
get !
;! "
set# &
;& '
}( )
public 
List 
< 
string 
> 
Textos "
{# $
get% (
;( )
set* -
;- .
}/ 0
public

 
Mensagem

 
(

 
Modelos

 
.

  
MensagemEntrada

  /
mensagemEntrada

0 ?
)

? @
{ 	
Texto 
= 
mensagemEntrada #
.# $
Texto$ )
;) *
} 	
public 
Mensagem 
( 
Mensagem  
mensagem! )
,) * 
OutputConversaWatson+ ? 
outputConversaWatson@ T
)T U
{ 	
Textos 
= 
new 
List 
< 
string $
>$ %
(% &
)& '
;' (
foreach 
( 
var 
input 
in ! 
outputConversaWatson" 6
?6 7
.7 8
Output8 >
.> ?
Generic? F
)F G
{H I
TextosJ P
.P Q
AddQ T
(T U
inputU Z
?Z [
.[ \
Textos\ b
)b c
;c d
}e f
;f g
} 	
} 
} ð
uC:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\Domain.Modelos\Watson\OutputConversaWatson.cs
	namespace 	
Domain
 
. 
Modelos 
. 
Watson 
{ 
public 

class  
OutputConversaWatson %
{ 
[ 	
JsonProperty	 
( 
$str 
, 
NullValueHandling  1
=2 3
NullValueHandling4 E
.E F
IncludeF M
)M N
]N O
public 
OutputWatson 
Output "
{# $
get% (
;( )
set* -
;- .
}/ 0
}		 
}

 ¦
mC:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\Domain.Modelos\Watson\OutputWatson.cs
	namespace 	
Domain
 
. 
Modelos 
. 
Watson 
{ 
public 

class 
OutputWatson 
{		 
[

 	
JsonProperty

	 
(

 
$str

 
,

  
NullValueHandling

! 2
=

3 4
NullValueHandling

5 F
.

F G
Include

G N
)

N O
]

O P
public 
List 
< 
Generic 
> 
Generic $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
object 
Textos 
{ 
get "
;" #
set$ '
;' (
}) *
} 
} Ò
jC:\Users\julia\Desktop\Treinamento\treinamento-watson\TreinamentoWatson\Domain.Modelos\Watson\UserInput.cs
	namespace 	
Domain
 
. 
Modelos 
. 
Watson 
{ 
public 

class 
	UserInput 
{ 
[ 	
JsonProperty	 
( 
$str 
, 
NullValueHandling /
=0 1
NullValueHandling2 C
.C D
IgnoreD J
)J K
]K L
public 
string 
Texto 
{ 
get !
;! "
set# &
;& '
}( )
}		 
}

 