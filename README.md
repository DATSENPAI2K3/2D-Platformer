# SKYBOUND – 2D Platformer

## Giới thiệu

Đây là dự án game 2D thể loại Platformer được phát triển bằng Unity và C#.

Người chơi điều khiển nhân vật vượt qua các chướng ngại vật, né tránh bẫy, đối đầu với kẻ địch và tìm cách hoàn thành màn chơi trong thời gian ngắn nhất.

## Tính năng đã thực hiện

* Hệ thống di chuyển nhân vật (Player Movement)
* Double Jump – cho phép nhân vật nhảy hai lần liên tiếp
* Dash – giúp nhân vật di chuyển nhanh trong một khoảng thời gian ngắn
* Enemy AI với cơ chế tuần tra (Patrol)
* Hệ thống máu và sát thương
* Cơ chế sử dụng chìa khóa để mở hộp chứa vật phẩm hồi máu
* Cơ chế tiêu diệt kẻ địch bằng cách nhảy lên đầu
* Hệ thống chướng ngại vật và bẫy (Spikes)
* Hệ thống Win/Lose
* Main Menu và giao diện trong game

## Các kỹ thuật sử dụng

### Player Movement

Sử dụng Rigidbody2D để xử lý chuyển động nhân vật, kết hợp với kiểm tra trạng thái tiếp đất để triển khai cơ chế Double Jump.

### Dash Mechanic

Triển khai cơ chế Dash cho phép nhân vật lướt nhanh theo hướng di chuyển, có thời gian sử dụng và thời gian hồi chiêu.

### Enemy AI

Xây dựng hệ thống Enemy Patrol cho phép kẻ địch di chuyển qua lại giữa các vị trí xác định, kết hợp với cơ chế phát hiện va chạm với người chơi.

### Collision Detection

Sử dụng Collider2D để xử lý va chạm giữa nhân vật, kẻ địch và các chướng ngại vật trong màn chơi.

## Công nghệ sử dụng

* Unity
* C#

## Video và hình ảnh gameplay

https://drive.google.com/drive/folders/1YudDhtRvP7cXDie_pZNnxw3xgWYcV_BD?usp=sharing

## Phiên bản Unity

Unity 2022.3.27f1
