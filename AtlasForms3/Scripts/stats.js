google.maps.__gjsload__('stats', function(_){var vZ=function(a,b,c){var d=[];_.Ob(a,function(a,c){d.push(c+b+a)});return d.join(c)},wZ=function(a,b,c,d){var e={};e.host=window.document.location&&window.document.location.host||window.location.host;e.v=a;e.r=Math.round(1/b);c&&(e.client=c);d&&(e.key=d);return e},xZ=function(a){var b={};_.Ob(a,function(a,d){b[(0,window.encodeURIComponent)(d)]=(0,window.encodeURIComponent)(a).replace(/%7C/g,"|")});return vZ(b,":",",")},zZ=function(a,b,c,d){var e;e=_.M(_.Q,23,500);var f;f=_.M(_.Q,22,2);this.C=a;
this.D=b;this.F=e;this.l=f;this.B=c;this.m=d;this.f=new _.dk;this.b=0;this.j=_.Pa();yZ(this)},yZ=function(a){window.setTimeout(function(){AZ(a);yZ(a)},Math.min(a.F*Math.pow(a.l,a.b),2147483647))},BZ=function(a,b,c){a.f.set(b,c)},AZ=function(a){var b=wZ(a.D,a.B,a.m,void 0);b.t=a.b+"-"+(_.Pa()-a.j);a.f.forEach(function(a,d){a=a();0<a&&(b[d]=Number(a.toFixed(2))+(_.Qk()?"-if":""))});a.C.b({ev:"api_snap"},b);++a.b},CZ=function(a,b,c,d,e){this.m=a;this.C=b;this.l=c;this.f=d;this.j=e;this.b=new _.dk;this.B=
_.Pa()},DZ=function(a,b,c){this.l=b;this.f=a+"/maps/gen_204";this.j=c},EZ=function(){this.b=new _.dk},FZ=function(a){var b=0,c=0;a.b.forEach(function(a){b+=a.bo;c+=a.Dn});return c?b/c:0},GZ=function(a,b,c,d){this.j=a;_.x.bind(this.j,"set_at",this,this.l);_.x.bind(this.j,"insert_at",this,this.l);this.B=b;this.C=c;this.m=d;this.f=0;this.b={};this.l()},HZ=function(a,b,c,d,e){this.B=a;this.C=b;this.m=c;this.j=d;this.l=e;this.f={};this.b=[]},IZ=function(){this.j=_.N(_.Q,6);this.b=new DZ(_.xg[35]?_.N(_.Tf(_.Q),
11):_.Ov,_.oj,window.document);new GZ(_.ij,(0,_.p)(this.b.b,this.b),_.mg,!!this.j);var a=_.N(new _.Ff(_.Q.data[3]),1);this.C=a.split(".")[1]||a;this.D={};this.B={};this.m={};this.F={};this.G=_.M(_.Q,0,1);_.nj&&(this.l=new zZ(this.b,this.C,this.G,this.j))};
CZ.prototype.D=function(a){var b=void 0,b=_.m(b)?b:1;this.b.isEmpty()&&window.setTimeout((0,_.p)(function(){var a=wZ(this.C,this.l,this.f,this.j);a.t=_.Pa()-this.B;var b=this.b;_.ek(b);for(var e={},f=0;f<b.b.length;f++){var g=b.b[f];e[g]=b.H[g]}_.dz(a,e);this.b.clear();this.m.b({ev:"api_maprft"},a)},this),500);b=this.b.get(a,0)+b;this.b.set(a,b)};
DZ.prototype.b=function(a,b){b=b||{};var c=_.Dl().toString(36);b.src="apiv3";b.token=this.l;b.ts=c.substr(c.length-6);a.cad=xZ(b);a=vZ(a,"=","&");a=this.f+"?target=api&"+a;this.j.createElement("img").src=a;(b=_.Kc.__gm_captureCSI)&&b(a)};EZ.prototype.f=function(a,b,c){this.b.set(_.ab(a),{bo:b,Dn:c})};
GZ.prototype.l=function(){for(var a;a=this.j.removeAt(0);){var b=a.fn;a=a.timestamp-this.C;++this.f;this.b[b]||(this.b[b]=0);++this.b[b];if(20<=this.f&&!(this.f%5)){var c={};c.s=b;c.sr=this.b[b];c.tr=this.f;c.te=a;c.hc=this.m?"1":"0";this.B({ev:"api_services"},c)}}};HZ.prototype.D=function(a){this.f[a]||(this.f[a]=!0,this.b.push(a),2>this.b.length&&_.pz(this,this.F,500))};HZ.prototype.F=function(){for(var a=wZ(this.C,this.m,this.j,this.l),b=0,c;c=this.b[b];++b)a[c]="1";a.hybrid=+_.Xl();this.b.length=0;this.B.b({ev:"api_mapft"},a)};IZ.prototype.S=function(a){a=_.ab(a);this.D[a]||(this.D[a]=new HZ(this.b,this.C,this.G,this.j));return this.D[a]};IZ.prototype.O=function(a){a=_.ab(a);this.B[a]||(this.B[a]=new CZ(this.b,this.C,1,this.j));return this.B[a]};IZ.prototype.f=function(a){if(this.l){this.m[a]||(this.m[a]=new _.wA,BZ(this.l,a,function(){return b.kb()}));var b=this.m[a];return b}};IZ.prototype.ba=function(a){if(this.l){this.F[a]||(this.F[a]=new EZ,BZ(this.l,a,function(){return FZ(b)}));var b=this.F[a];return b}};var JZ=new IZ;_.dd("stats",JZ);});
