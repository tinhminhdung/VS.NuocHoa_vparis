$(document).ready(function ($) {
	"use strict";
	dl_backtotop();
	dl_category();
	dl_menumobile();
	dl_tab();		
	dl_lazyloadImage();
	dl_owl();

	$('.product-box .time').each(function(e){
		dl_countDown($(this));
	})

	$('#nav-mobile .fa').click(function(e){		
		e.preventDefault();
		$(this).parent().parent().toggleClass('open');
	});
	$('.button-mobile').click(function(e){			
		$('.section_tab_product .tabs-title').slideToggle('fast');
	});
	$('.menu-bar').click(function(e){
		e.preventDefault();
		$('#nav-mobile').toggleClass('open');
		$('.menu-offcanvas').toggleClass('open');
	});
	$('.menuclose').click(function(e){
		$('#nav-mobile').removeClass('open');
		$('.menu-offcanvas').removeClass('open');
	})

	$('.open-filters').click(function(e){
		$(this).toggleClass('open');
		$('.dqdt-sidebar').toggleClass('open');
		$('#nav-mobile').removeClass('open');
	});
	$('footer .footer-widget h3').click(function(e){		
		e.preventDefault();
		$(this).parent().toggleClass('active');
	});


	//$('body').scrollspy({target: "#myScrollspy", offset: 70}); 
	var $root = $('html, body');
	$('.scroll_menu a').click(function() {
		var location = $( $.attr(this, 'href') ).offset().top - 50;
		$root.animate({
			scrollTop: location
		}, 500);
		return false;
	});



});

$(document).on('click','.overlay, .close-popup, .btn-continue, .fancybox-close', function() {   
	setTimeout(function(){
		$('.loading').removeClass('loaded-content');
	},500);
	return false;
})

$(window).load(function() {

	$(this).scroll(function() {
		var height = $(window).scrollTop();
		if(height >= 400) {
			$('.scroll_menu').addClass('visible');
		}
		else {
			$('.scroll_menu').removeClass('visible');
		}
	});
});

/********************************************************
# LazyLoad
********************************************************/
function dl_lazyloadImage() {
	var i = $("[data-lazyload]");
	i.length > 0 && i.each(function() {
		var i = $(this), e = i.attr("data-lazyload");
		i.appear(function() {
			i.removeAttr("height").attr("src", e);
		}, {
			accX: 0,
			accY: 120
		}, "easeInCubic");
	});
	var e = $("[data-lazyload2]");
	e.length > 0 && e.each(function() {
		var i = $(this), e = i.attr("data-lazyload2");
		i.appear(function() {
			i.css("background-image", "url(" + e + ")");
		}, {
			accX: 0,
			accY: 120
		}, "easeInCubic");
	});
} window.dl_lazyloadImage=dl_lazyloadImage;

/********************************************************
# SHOW NOITICE
********************************************************/
function dl_showNoitice(selector) {
	$(selector).animate({right: '0'}, 500);
	setTimeout(function() {
		$(selector).animate({right: '-300px'}, 500);
	}, 3500);
}  window.dl_showNoitice=dl_showNoitice;

/********************************************************
# SHOW LOADING
********************************************************/
function dl_showLoading(selector) {
	var loading = $('.loader').html();
	$(selector).addClass("loading").append(loading); 
}  window.dl_showLoading=dl_showLoading;

/********************************************************
# HIDE LOADING
********************************************************/
function dl_hideLoading(selector) {
	$(selector).removeClass("loading"); 
	$(selector + ' .loading-icon').remove();
}  window.dl_hideLoading=dl_hideLoading;

/********************************************************
# SHOW POPUP
********************************************************/
function dl_showPopup(selector) {
	$(selector).addClass('active');
}  window.dl_showPopup=dl_showPopup;

/********************************************************
# HIDE POPUP
********************************************************/
function dl_hidePopup(selector) {
	$(selector).removeClass('active');
}  window.dl_hidePopup=dl_hidePopup;

/********************************************************
# CONVERT VIETNAMESE
********************************************************/
function dl_convertVietnamese(str) { 
	str= str.toLowerCase();
	str= str.replace(/??|??|???|???|??|??|???|???|???|???|???|??|???|???|???|???|???|a??|a??|a??|a??|a??|??|????|????|????|????|????|??|????|????|????|????|????/g,"a"); 
	str= str.replace(/??|??|???|???|???|??|???|???|???|???|???|e??|e??|e??|e??|e??|??|????|????|????|????|????/g,"e"); 
	str= str.replace(/??|??|???|???|??|i??|i??|i??|i??|i??|i??||i??|i/g,"i"); 
	str= str.replace(/??|??|???|???|??|??|???|???|???|???|???|??|???|???|???|???|???|o??|o??|o??|o??|o??|??|????|????|????|????|????|??|????|????|????|????|????/g,"o"); 
	str= str.replace(/??|??|???|???|??|??|???|???|???|???|???|u??|u??|u??|u??|u??|??|????|????|????|????|????|????/g,"u"); 
	str= str.replace(/???|??|???|???|???|y??|y??|y??|y??|y/g,"y"); 
	str= str.replace(/??|??/g,"d"); 
	str= str.replace(/!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'| |\"|\&|\#|\[|\]|~|$|_/g,"-");
	str= str.replace(/-+-/g,"-");
	str= str.replace(/^\-+|\-+$/g,""); 
	return str; 
} window.dl_convertVietnamese=dl_convertVietnamese;


/********************************************************
# SIDEBAR CATEOGRY
********************************************************/
function dl_category(){
	$('.nav-category .fa-angle-down').click(function(e){
		$(this).parent().toggleClass('active');
	});
} window.dl_category=dl_category;

/********************************************************
# MENU MOBILE
********************************************************/
function dl_menumobile(){
	$('.menu-bar').click(function(e){
		e.preventDefault();
		$('#nav').toggleClass('open');
		$('.dqdt-sidebar').removeClass('open');
		$('#open-filters').removeClass('open');
	});
	$('#nav .fa').click(function(e){		
		e.preventDefault();
		$(this).parent().parent().toggleClass('open');
	});
} window.dl_menumobile=dl_menumobile;

/********************************************************
# ACCORDION
********************************************************/
function dl_accordion(){
	$('.accordion .nav-link').click(function(e){
		e.preventDefault;
		$(this).parent().toggleClass('active');
	})
} window.dl_accordion=dl_accordion;

/********************************************************
# OWL CAROUSEL
********************************************************/
function dl_owl() { 
	$('.owl-carousel:not(.not-aweowl)').each( function(){
		var xss_item = $(this).attr('data-xss-items');
		var xs_item = $(this).attr('data-xs-items');		
		var sm_item = $(this).attr('data-sm-items');
		var md_item = $(this).attr('data-md-items');
		var lg_item = $(this).attr('data-lg-items');
		var lgg_item = $(this).attr('data-lgg-items');
		var margin=$(this).attr('data-margin');
		var dot=$(this).attr('data-dot');
		var nav=$(this).attr('data-nav');
		if (typeof margin !== typeof undefined && margin !== false) {    
		} else{
			margin = 30;
		}
		if (typeof xss_item !== typeof undefined && xss_item !== false) {    
		} else{
			xss_item = 1;
		}
		if (typeof xs_item !== typeof undefined && xs_item !== false) {    
		} else{
			xs_item = 1;
		}
		if (typeof sm_item !== typeof undefined && sm_item !== false) {    

		} else{
			sm_item = 3;
		}	
		if (typeof md_item !== typeof undefined && md_item !== false) {    
		} else{
			md_item = 3;
		}
		if (typeof lg_item !== typeof undefined && lg_item !== false) {    
		} else{
			lg_item = 4;
		}
		if (typeof lgg_item !== typeof undefined && lg_item !== false) {    
		} else{
			lgg_item = lg_item;
		}
		if (typeof dot !== typeof undefined && dot !== true) {   
			dot = dot;
		} else{
			dot = false;
		}
		if (typeof nav !== typeof undefined && nav !== true) {   
			nav = nav;
		} else{
			nav = false;
		}
		$(this).owlCarousel({
			loop:false,
			margin:Number(margin),
			responsiveClass:true,
			dots:dot,
			autoHeight: false,
			nav:nav,
			navText: ["<i class='fa fa-angle-left'></i>","<i class='fa fa-angle-right'></i>"],
			responsive:{
				0:{
					items:Number(xss_item),
					margin:15
				},
				543:{
					items:Number(xs_item),
					margin:15
				},
				768:{
					items:Number(sm_item)				
				},
				992:{
					items:Number(md_item)				
				},
				1200:{
					items:Number(lg_item)				
				},
				1500:{
					items:Number(lgg_item)				
				}
			}
		})
	})
} window.dl_owl=dl_owl;

/********************************************************
# BACKTOTOP
********************************************************/
function dl_backtotop() { 
	if ($('.back-to-top').length) {
		var scrollTrigger = 100, // px
			backToTop = function () {
				var scrollTop = $(window).scrollTop();
				if (scrollTop > scrollTrigger) {
					$('.back-to-top').addClass('show');
				} else {
					$('.back-to-top').removeClass('show');
				}
			};
		backToTop();
		$(window).on('scroll', function () {
			backToTop();
		});
		$('.back-to-top').on('click', function (e) {
			e.preventDefault();
			$('html,body').animate({
				scrollTop: 0
			}, 700);
		});
	}
} window.dl_backtotop=dl_backtotop;

/********************************************************
# Countdown
********************************************************/
function dl_countDown(selector){	
	// Set the date we're counting down to
	var dataTime = selector.attr('data-time');
	var countDownDate = new Date(dataTime).getTime();
	// Update the count down every 1 second
	var x = setInterval(function() {
		// Get todays date and time
		var now = new Date().getTime();
		// Find the distance between now an the count down date
		var distance = countDownDate - now;
		// Time calculations for days, hours, minutes and seconds
		var days = Math.floor(distance / (1000 * 60 * 60 * 24));
		var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
		var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
		var seconds = Math.floor((distance % (1000 * 60)) / 1000);
		// Display the result in the element 
		selector.html(days + " ng??y " + hours + ":"
					  + minutes + ":" + seconds);
		// If the count down is finished, write some text 
		if (distance < 0) {
			clearInterval(x);
			selector.html("H???t h???n");
		}
	}, 1000);
}

/********************************************************
# TAB
********************************************************/
function dl_tab() {
	$(".e-tabs:not(.not-dqtab)").each( function(){
		$(this).find('.tabs-title li:first-child').addClass('current');
		$(this).find('.tab-content').first().addClass('current');
		$(this).find('.tabs-title li').click(function(){
			if($(window).width() < 767 ){
				$('.section_tab_product .tabs-title').hide();
			}
			var tab_id = $(this).attr('data-tab');
			var url = $(this).attr('data-url');
			$(this).closest('.e-tabs').find('.tab-viewall').attr('href',url);
			$(this).closest('.e-tabs').find('.tabs-title li').removeClass('current');
			$(this).closest('.e-tabs').find('.tab-content').removeClass('current');
			$(this).addClass('current');
			$(this).closest('.e-tabs').find("."+tab_id).addClass('current');
			$(this).closest('.e-tabs').find('.section-title > a').removeClass('current');			
			$(this).closest('.e-tabs').find(".section-title > a."+tab_id).addClass('current');
		});    
	});
} window.dl_tab=dl_tab;

/********************************************************
# DROPDOWN
********************************************************/
$('.dropdown-toggle').click(function() {
	$(this).parent().toggleClass('open'); 	
}); 
$('.btn-close').click(function() {
	$(this).parents('.dropdown').toggleClass('open');
}); 

$(document).on('click','.qtyplus',function(e){
	e.preventDefault();   
	fieldName = $(this).attr('data-field'); 
	var currentVal = parseInt($('input[data-field='+fieldName+']').val());
	if (!isNaN(currentVal)) { 
		$('input[data-field='+fieldName+']').val(currentVal + 1);
	} else {
		$('input[data-field='+fieldName+']').val(0);
	}
});

$(document).on('click','.qtyminus',function(e){
	e.preventDefault(); 
	fieldName = $(this).attr('data-field');
	var currentVal = parseInt($('input[data-field='+fieldName+']').val());
	if (!isNaN(currentVal) && currentVal > 1) {          
		$('input[data-field='+fieldName+']').val(currentVal - 1);
	} else {
		$('input[data-field='+fieldName+']').val(1);
	}
});

$(document).on('click', function(event) {
	if (!$(event.target).closest('.dqdt-sidebar').length && !$(event.target).closest('#open-filters').length) {
		$('.dqdt-sidebar').removeClass('open');
		$('#open-filters').removeClass('open');
	}

	if (!$(event.target).closest('.menu-bar').length && !$(event.target).closest('.menu-offcanvas').length) {		
		$('#nav-mobile').removeClass('open');
		$('.menu-offcanvas').removeClass('open');
	}
});

window.onscroll = function() {menuSticky()};
var navbar = $("header nav");
// Get the offset position of the navbar
var sticky = 40;
// Add the sticky class to the navbar when you reach its scroll position. Remove "sticky" when you leave the scroll position
function menuSticky() {	
	if (window.pageYOffset >= sticky) {
		navbar.addClass("sticky")
	} else {
		navbar.removeClass("sticky");
	}
}




/* top search */
$(function(){				

	var $win = $(window); // or $box parent container
	var $search_text = $(".header-content-search .search_text");
	var $list_search = $(".header-content-search .list_search");

	$win.on("click.Bst", function(event){		
		if ( 
			$search_text.has(event.target).length == 0 //checks if descendants of $box was clicked
			&&
			!$search_text.is(event.target) //checks if the $box itself was clicked
		){
			$list_search.hide();
		} else {
			$list_search.show();
		}
	});

});

$('.search_text').click(function(){
	$(this).next().slideToggle(200);
	$('.list_search').show();
})

$('.list_search .search_item').on('click', function (e) {
	$('.list_search').hide();

	var optionSelected = $(this);

	/*
  var id = optionSelected.attr('data-coll-id');
  var handle = optionSelected.attr('data-coll-handle');
  var coll_name = optionSelected.attr('data-coll-name');
  */

	var title = optionSelected.text();
	//var filter = '(collectionid:product' + (id == 0 ? '>=0' : ('=' + id)) + ')';


	//console.log(coll_name);
	$('.search_text').text(title);
	var h = $(".collection-selector").width() + 10;

	$('.site-header form input').css('padding-left',h + 'px');

	/*
  $('.ultimate-search .collection_id').val(filter);
  $('.ultimate-search .collection_handle').val(handle);
  $('.ultimate-search .collection_name').val(coll_name);
  */

	$(".search-text").focus();
	optionSelected.addClass('active').siblings().removeClass('active');
	//console.log($('.kd_search_text').innerWidth());


	//$('.list_search').slideToggle(0);

	/*
  sessionStorage.setItem('last_search', JSON.stringify({
    title: title,
    handle: handle,
    filter: filter,
    name: coll_name
  }));
  */  
});


$('.header_search form button').click(function(e) {
	if($(window).width() > 992){
		e.preventDefault();
		searchCollection();
		setSearchStorage('.header_search form');
	}
});

$('#mb_search').click(function(){
	$('.mb_header_search').slideToggle('fast');
});

$('.fi-title.drop-down').click(function(){
	$(this).toggleClass('opentab');
});



function searchCollection() {
	var collectionId = $('.list_search .search_item.active').attr('data-coll-id');
	var searchVal = $('.header_search input[type="search"]').val();
	var url = '';
	if(collectionId == 0) {
		url = '/search?q='+ searchVal;
	}
	else {
		url = '/search?q=collections:'+ collectionId +' AND name:' + searchVal;
		/*
    if(searchVal != '') {
      url = '/search?type=product&q=' + searchVal + '&filter=(collectionid:product=' + collectionId + ')';
    }
    else {
      url = '/search?type=product&q=filter=(collectionid:product=' + collectionId + ')';
    }
    */
	}
	window.location=url;
}


/*** Search Storage ****/

function setSearchStorage(form_id) {
	var seach_input = $(form_id).find('.search-text').val();
	var search_collection = $(form_id).find('.list_search .search_item.active').attr('data-coll-id');
	sessionStorage.setItem('search_input', seach_input);
	sessionStorage.setItem('search_collection', search_collection);
}
function getSearchStorage(form_id) {
	var search_input_st = ''; // sessionStorage.getItem('search_input');
	var search_collection_st = ''; // sessionStorage.getItem('search_collection');
	if(sessionStorage.search_input != '') {
		search_input_st = sessionStorage.search_input;
	}
	if(sessionStorage.search_collection != '') {
		search_collection_st = sessionStorage.search_collection;
	}
	$(form_id).find('.search-text').val(search_input_st);
	$(form_id).find('.search_item[data-coll-id="'+search_collection_st+'"]').addClass('active').siblings().removeClass('active');
	var search_key = $(form_id).find('.search_item[data-coll-id="'+search_collection_st+'"]').text();
	if(search_key != ''){
		$(form_id).find('.collection-selector .search_text').text(search_key);
	}
	//$(form_id).find('.search_collection option[value="'+search_collection_st+'"]').prop('selected', true);
}
function resetSearchStorage() {
	sessionStorage.removeItem('search_input');
	sessionStorage.removeItem('search_collection');
}
$('li.lev-1.nav-item.has-mega.mega-menu').hover(function(e){
	if($(window).width() > 1200){
		var meh = $('.cate-sidebar').height();
		$('li.lev-1.nav-item.has-mega.mega-menu .mega-menu-content').css('min-height',meh +1);
	}
})
$(window).load(function() {
	if($(window).width() > 992){
		var meh = $('.cate-sidebar').height();
		$('li.lev-1.nav-item.has-mega.mega-menu .mega-menu-content').css('min-height',meh + 1);

		getSearchStorage('.header_search form');
		resetSearchStorage();
		var h = $(".collection-selector").width() + 10;
		$('.site-header form input').css('padding-left',h + 'px');
		$('.bot-header-left').mouseover(function(e){
			$('.catogory-other-page').addClass('active');
		})
	}
	$('body').mouseover(function(event) {
		if (!$(event.target).closest('.bot-header-left').length && !$(event.target).closest('.catogory-other-page').length){
			$('.catogory-other-page').removeClass('active');
		};
	});
});




// Create tab
$(".not-dqtab").each( function(e){
	var $this1 = $(this);
	var datasection = $this1.closest('.not-dqtab').attr('data-section');
	var view = $this1.closest('.not-dqtab').attr('data-view');
	$this1.find('.tabs-title li:first-child').addClass('current');
	$this1.find('.tab-content').first().addClass('current');
	$this1.find('.tabs-title.ajax li').click(function(){
		var $this2 = $(this),
			tab_id = $this2.attr('data-tab'),
			url = $this2.attr('data-url');
		var etabs = $this2.closest('.e-tabs');
		etabs.find('.tab-viewall').attr('href',url);
		etabs.find('.tabs-title li').removeClass('current');
		etabs.find('.tab-content').removeClass('current');
		$this2.addClass('current');
		etabs.find("."+tab_id).addClass('current');
		//N???u ???? load r???i th?? kh??ng load n???a
		if(!$this2.hasClass('has-content')){
			$this2.addClass('has-content');		
			getContentTab(url,"."+ datasection+" ."+tab_id,view);
		}
	});
});

//X??? l?? mobile

$('.not-dqtab .next').click(function(e){

	var count = 0
	$(this).parents('.content').find('.tab-content').each(function(e){
		count +=1;
	})

	var str = $(this).parent().find('.tab-titlexs').attr('data-tab'),
		res = str.replace("tab-", ""),
		datasection = $(this).closest('.not-dqtab').attr('data-section');
	res = Number(res);
	if(res < count){
		var current = res + 1;
	}else{
		var current = 1;
	}
	action(current,datasection);
})
$('.not-dqtab .prev').click(function(e){
	var count = 0
	$(this).parents('.content').find('.tab-content').each(function(e){
		count +=1;
	})

	var str = $(this).parent().find('.tab-titlexs').attr('data-tab'),
		res = str.replace("tab-", ""),
		datasection = $(this).closest('.not-dqtab').attr('data-section'),
		res = Number(res);	
	if(res > 1){
		var current = res - 1;
	}else{
		var current = count;
	}
	action(current,datasection);
})
// Action mobile
function action(current,datasection,view){
	$('.'+datasection+' .tab-titlexs').attr('data-tab','tab-'+current);
	var text = '',
		url = '',
		tab_id='';
	$('.'+datasection+' ul.tabs.tabs-title.hidden-xs li').each(function(e){

		if($(this).attr('data-tab') == 'tab-'+current){
			var $this3 = $(this);
			title = $this3.find('span').text();
			url = $this3.attr('data-url');
			tab_id = $this3.attr('data-tab');	
			//N???u ???? load r???i th?? kh??ng load n???a
			if(!$this3.hasClass('has-content')){
				$this3.addClass('has-content');	

				getContentTab(url,"."+ datasection+" ."+tab_id,view);				
			}
		}
	})
	$("."+ datasection+" .tab-titlexs span").text(title);
	$("."+ datasection+" .tab-content").removeClass('current');

	$("."+ datasection+" .tab-"+current).addClass('current');

}
// Get content cho tab
function getContentTab(url,selector,view){	
	if(view == 'grid_8'){
		url = url+"?view=ajaxloadgrid";
	}else{
		url = url+"?view=ajaxload";
	}

	var dataLgg = $(selector).parent().find('.tab-1 .owl-carousel').attr('data-lgg-items');
	var loadding = '<div class="a-center"><svg height=30px style="enable-background:new 0 0 50 50"version=1.1 viewBox="0 0 24 30"width=24px x=0px xml:space=preserve xmlns=http://www.w3.org/2000/svg xmlns:xlink=http://www.w3.org/1999/xlink y=0px><rect fill=#333 height=10 opacity=0.2 width=4 x=0 y=10><animate attributeName=opacity attributeType=XML begin=0s dur=0.6s repeatCount=indefinite values="0.2; 1; .2"/><animate attributeName=height attributeType=XML begin=0s dur=0.6s repeatCount=indefinite values="10; 20; 10"/><animate attributeName=y attributeType=XML begin=0s dur=0.6s repeatCount=indefinite values="10; 5; 10"/></rect><rect fill=#333 height=10 opacity=0.2 width=4 x=8 y=10><animate attributeName=opacity attributeType=XML begin=0.15s dur=0.6s repeatCount=indefinite values="0.2; 1; .2"/><animate attributeName=height attributeType=XML begin=0.15s dur=0.6s repeatCount=indefinite values="10; 20; 10"/><animate attributeName=y attributeType=XML begin=0.15s dur=0.6s repeatCount=indefinite values="10; 5; 10"/></rect><rect fill=#333 height=10 opacity=0.2 width=4 x=16 y=10><animate attributeName=opacity attributeType=XML begin=0.3s dur=0.6s repeatCount=indefinite values="0.2; 1; .2"/><animate attributeName=height attributeType=XML begin=0.3s dur=0.6s repeatCount=indefinite values="10; 20; 10"/><animate attributeName=y attributeType=XML begin=0.3s dur=0.6s repeatCount=indefinite values="10; 5; 10"/></rect></svg></div>';

	$.ajax({
		type: 'GET',
		url: url,
		beforeSend: function() {
			$(selector).html(loadding);
		},
		success: function(data) {
			var content = $(data);

			$(selector).html(content.html());
			ajaxCarousel(selector,dataLgg);			
			dl_lazyloadImage();
			$('.ajaxcol .add_to_cart').bind( 'click', addToCart );
			//Fix app
			if(window.BPR)
				return window.BPR.initDomEls(), window.BPR.loadBadges();
		},
		dataType: "html"
	});
}
// Ajax carousel
function ajaxCarousel(selector,dataLgg){

	$(selector+' .owl-carousel.ajax-carousel').each( function(){
		var xss_item = $(this).attr('data-xss-items');
		var xs_item = $(this).attr('data-xs-items');
		var sm_item = $(this).attr('data-sm-items');
		var md_item = $(this).attr('data-md-items');
		var lg_item = $(this).attr('data-lg-items');
		if(dataLgg !== typeof undefined){

		}
		var lgg_item = dataLgg;
		var margin=$(this).attr('data-margin');
		var dot=$(this).attr('data-dot');
		var nav=$(this).attr('data-nav');
		if (typeof margin !== typeof undefined && margin !== false) {
		} else{
			margin = 30;
		}
		if (typeof xss_item !== typeof undefined && xss_item !== false) {
		} else{
			xss_item = 1;
		}
		if (typeof xs_item !== typeof undefined && xs_item !== false) {
		} else{
			xs_item = 1;
		}
		if (typeof sm_item !== typeof undefined && sm_item !== false) {

		} else{
			sm_item = 3;
		}
		if (typeof md_item !== typeof undefined && md_item !== false) {
		} else{
			md_item = 3;
		}
		if (typeof lg_item !== typeof undefined && lg_item !== false) {
		} else{
			lg_item = 4;
		}
		if (typeof lgg_item !== typeof undefined && lgg_item !== false) {

		} else{
			lgg_item = lg_item;			
		}

		if (typeof dot !== typeof undefined && dot !== true) {
			dot = dot;
		} else{
			dot = false;
		}
		if (typeof nav !== typeof undefined && nav !== true) {
			nav = nav;
		} else{
			nav = false;
		}
		$(this).owlCarousel({
			loop:false,
			margin:Number(margin),
			responsiveClass:true,
			dots:dot,
			nav:nav,
			responsive:{
				0:{
					items:Number(xss_item),
					margin:15
				},
				543:{
					items:Number(xs_item),
					margin:15
				},
				768:{
					items:Number(sm_item)
				},
				992:{
					items:Number(md_item)
				},
				1200:{
					items:Number(lg_item)
				},
				1500:{
					items:Number(lgg_item)
				}
			}
		})
	})
}


$('.xemthem').click(function(e){
	e.preventDefault();
	$('.aside-vetical-menu .aside-content>.nav-category>ul>.nav-item').css('display','block');
	$(this).hide();
	$('.thugon').show();
})
$('.thugon').click(function(e){
	e.preventDefault();
	$('.aside-vetical-menu .aside-content>.nav-category>ul>.nav-item').css('display','none');
	$(this).hide();
	$('.xemthem').show();
})

 $(document).on('keydown','.fixnumber',function(e){-1!==$.inArray(e.keyCode,[46,8,9,27,13,110,190])||/65|67|86|88/.test(e.keyCode)&&(!0===e.ctrlKey||!0===e.metaKey)||35<=e.keyCode&&40>=e.keyCode||(e.shiftKey||48>e.keyCode||57<e.keyCode)&&(96>e.keyCode||105<e.keyCode)&&e.preventDefault()});




$(document).ready(function() {
	    scrollSliderBarMenu();
	$(".verticalmenu .button-verticalmenu").click(function() {
        var $parent = $(this).parent().parent();
        $parent.toggleClass('open')
        return false;
    });
});
function scrollSliderBarMenu() {
    var menuElement = $(".float-vertical");
    var columnElement = null;
    var maxWindowSize = 990;
    if ($(menuElement).hasClass('float-vertical-right'))
        columnElement = $("#right_column");
    else if ($(menuElement).hasClass('float-vertical-left'))
        columnElement = $("#left_column");
    if ($(columnElement).length && $(window).width() >= maxWindowSize) showOrHideSliderBarMenu(columnElement, menuElement, 1);
    $(".float-vertical-button").click(function() {
        if ($(menuElement).hasClass('active')) showOrHideSliderBarMenu(columnElement, menuElement, 0);
        else showOrHideSliderBarMenu(columnElement, menuElement, 1);
    });
    var lastWidth = $(window).width();
    $(window).resize(function() {
        if ($(window).width() != lastWidth) {
            if ($(window).width() < maxWindowSize) {
                if ($(menuElement).hasClass('active')) showOrHideSliderBarMenu(columnElement, menuElement, 0);
            } else {
                if ($(columnElement).length && !$(menuElement).hasClass('active')) showOrHideSliderBarMenu(columnElement, menuElement, 1);
            }
            lastWidth = $(window).width();
        }
    });
}

function showOrHideSliderBarMenu(columnElement, menuElement, active) {
    if (active) {
        $(menuElement).addClass('active');
		$('.bg-vertical').addClass('fixed');
        if ($(columnElement).length && $(window).width() >= 990)
            columnElement.css('padding-top', ($('.block_content', $(menuElement)).height() - 90) + 'px');
    } else {
        $(menuElement).removeClass('active');
        if ($(columnElement).length) columnElement.css('padding-top', '');
		$('.bg-vertical').removeClass('fixed');
    }
}
$(".bg-vertical").click(function() {
	if($(this).hasClass('fixed')){
	   $('.bg-vertical').removeClass('fixed');
	   $('.float-vertical-button').parent().removeClass('active');
	}
});