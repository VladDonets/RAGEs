mp.events.add('PlayerSpawn', (player) => {
  // Устанавливаем параметры внешности игрока
	//1) индекс элемента одежды  //2) индекс стиля одежды //3)индекс цвета //4) индекс текстуры
  player.setClothes(0, 0, 1, 1); // шляпа
  player.setClothes(1, 0, 1, 1); // маска
  player.setClothes(2, 21, 1, 1); // волосы
  player.setClothes(3, 169, 1, 1); // руки
  player.setClothes(4, 115, 1, 1); // штаны
  player.setClothes(6, 70, 1, 1); // обувь
  player.setClothes(11, 18, 1, 1); // тело
});