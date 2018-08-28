//// Show Form Toggle
//$('header button').click(function(e){
//  e.preventDefault
//  console.log(e.currentTarget.parentElement.parentElement.getElementsByClassName("quantity")[0].innerText);
//  $('#formQuantity').attr('max', e.currentTarget.parentElement.parentElement.getElementsByClassName("quantity")[0].innerText);
//  $('form > div:nth-of-type(1)').addClass('openForm'),
//  $('nav').addClass('navFade')
//})
//$('.dismiss').click(function(){
//  $('form > div:nth-of-type(1)').removeClass('openForm'),
//  $('nav').removeClass('navFade')
//})


// Webshim Polyfill Options
webshim.setOptions({
  'forms': {
    lazyCustomMessages: true,
    replaceValidationUI: true,
    iVal: {
      'fx': 'fade'
    }
  },
	'forms-ext': {
		widgets: {
      openOnFocus: true,
      animate: true,
		},
    date: {
      classes: 'hide-spinbtns hide-dropdownbtn hide-btnrow show-selectnav'
    },
    time: {
      classes: 'hide-spinbtns hide-dropdownbtn hide-btnrow'
    },
    range: {
      classes: 'show-activevaluetooltip'
    }
	}
});
webshim.polyfill('forms forms-ext');

// Label Animation Class Toggle
$('input').focusin(function(){
  $(this).next('input.ws-inputreplace').addClass('isActive');
  $(this).prev('label').addClass('hasInput')
})
$('input').focusout(function(){
  if($(this).val() == ''){
    $(this).next('input.ws-inputreplace').removeClass('isActive');
    $(this).prev('label').removeClass('hasInput')
  }
})
