// Thẻ tabs
$(document).ready(function () {
    // Hàm active tab nào đó
    function activeTab(obj) {
        // Xóa class active tất cả các tab
        $('.tab-wrapper ul li').removeClass('active');

        // Thêm class active vòa tab đang click
        $(obj).addClass('active');

        // Lấy href của tab để show content tương ứng
        var id = $(obj).find('a').attr('href');

        // Ẩn hết nội dung các tab đang hiển thị
        $('.tab-item').hide();

        // Hiển thị nội dung của tab hiện tại
        $(id).show();
    }

    // Sự kiện click đổi tab
    $('.tab li').click(function () {
        activeTab(this);
        return false;
    });

    // Active tab đầu tiên khi trang web được chạy
    activeTab($('.tab li:first-child'));
});


// Submenu

$('#menu > li').hover(function() {
    // khi thẻ menu li bị hover thì drop down menu thuộc thẻ li đó sẽ trượt xuống(hiện)
    $('.dropdown_menu', this).slideDown();
  },function() {
    // khi thẻ menu li bị out không hover nữa thì drop down menu thuộc thẻ li đó sẽ trượt lên(ẩn)
    $('.dropdown_menu', this).slideUp();
  });

  $('.dropdown_menu > li').hover(function() {
    // khi thẻ dropdown_menu li bị hover thì submenusubmenu thuộc thẻ li đó sẽ trượt xuống(hiện)
    $('.submenu', this).slideDown();
  },function() {
    // khi thẻ dropdown_menu li bị hover thì submenusubmenu thuộc thẻ li đó sẽ trượt lên(ẩnẩn)
    $('.submenu', this).slideUp();
  });



//   const search = () => {
//     const searchBox = document.getElementById("search").value.toUpperCase();
//     const memItem = document.getElementById("feature");
//     const member = document.querySelectorAll(".fe-box");
//     const memName = memItem.getElementsByTagName("h6");

//     for (var i = 0; i < memName.length; i++) {
//         let match = member[i].getElementsByTagName('h6')[0];

//         if (match) {
//             let textValue = match.textContent || match.innerHTML

//             if (textValue.toUpperCase().indexOf(searchBox) > -1) {
//                 member[i].style.display = "";
//             } else {
//                 member[i].style.display = "none";
//             }
//         }
//     }
// }