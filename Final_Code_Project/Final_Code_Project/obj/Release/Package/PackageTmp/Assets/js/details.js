// $(document).ready(function(){
//     $(document).on("click",".product_details .cart_fav a",function(){
//         if($(".product_details .cart_fav a img").attr("src","https://img.icons8.com/ultraviolet/40/000000/hearts.png")){
//             $(".fav_icon img").attr("src","https://img.icons8.com/office/40/000000/hearts.png");
//         }else{
//             $(".fav_icon img").attr("src","https://img.icons8.com/ultraviolet/40/000000/hearts.png");
//         }
//     })
// })

// if($(".product_details .cart_fav a img").attr("src","https://img.icons8.com/ultraviolet/40/000000/hearts.png")){
//         $(document).on("click",".product_details .cart_fav a",function(){
//             $(".fav_icon img").attr("src","https://img.icons8.com/office/40/000000/hearts.png");
//         })
//     }else{
//         $(document).on("click",".product_details .cart_fav a",function(){
//             $(".fav_icon img").attr("src","https://img.icons8.com/ultraviolet/40/000000/hearts.png");
//     })


// Favorite Button - Heart

$(function() {
  $('.button-like')
    .bind('click', function(event) {
      $(".button-like").toggleClass("liked");
    })
});