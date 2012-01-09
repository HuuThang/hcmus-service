// JavaScript Document
$(document).ready(function(){
	$("#keyword").mouseover(function(e){
		if(!$(this).is(":focus")){
			$(this).css("border-color","#000");
		}
	});
	$("#keyword").mouseout(function(e){
		if(!$(this).is(":focus")){
			$(this).css("border-color","#C9C9C9");
		}
	});
	$("#keyword").focus(function(e){
		$(this).css("border-color","#37E");
	});
	$("#keyword").blur(function(e){
		$(this).css("border-color","#D9D9D9");
	});
	
	
	
	
});