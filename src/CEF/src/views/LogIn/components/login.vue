<template>
  <div :class="$style.login">
    <div :class="$style.logo_container">
      <img :class="$style.logo" src="@images/login-logo.png">
    </div>
    <div :class="$style.header">{{ route_info[route].name }}</div>
    <div :class="$style.welcome"
         v-html="route === 2 ?
         'Если вы забыли логин или пароль, то введите данные ниже' : 'Добро пожаловать на сервер <span>ALYX RolePlay</span>'"></div>
    <div :class="$style.input" v-for="(field, index) in fields.filter(x => x.on.includes(route))" :key="index">
      <img :class="$style.field_icon" :src="field.icon" alt="Loading">
      <input :placeholder="field.placeholder" :type="field.type || 'text'" v-model.trim="field.value">
    </div>
    <button :class="$style.button" @click="ClickNext">{{ route_info[route].button }}</button>
    <template v-if="route === 0">
      <div :class="$style.but_hrefs">
        <button :class="$style.to_login" @click="route = 2">Забыли пароль?</button>
        <button :class="$style.to_login" @click="route = 1">У меня нет аккаунта</button>
      </div>
      <div :class="$style.save">
        <div :class="$style.checkbox" @click="isSave = !isSave">
          <div :class="$style.check_yes" v-show="isSave"></div>
        </div>
        <span :class="$style.check_text">Запомнить меня</span>
      </div>
    </template>
    <button :class="$style.to_login" v-show="route === 1" @click="route = 0">У меня есть аккаунт</button>
    <button :class="$style.to_login" v-show="route === 2" @click="route = 0">Вернуться назад</button>
  </div>
</template>

<script lang="ts" setup>
import icon_mail from "@images/login-icon-mail.svg";
import icon_user from "@images/login-icon-user.svg";
import icon_pass from "@images/login-icon-pass.svg";
import icon_star from "@images/login-icon-star.svg";
import {Notify, NotifyType} from "../../../stores/Notify";
import Rage from "@services/Rage";

let route = $ref(0);
const route_info = [
  {
    name: 'Авторизация',
    button: 'Войти на сервер'
  },
  {
    name: 'Регистрация',
    button: 'Зарегистрироваться'
  },
  {
    name: 'Восстановление аккаунта',
    button: 'Восстановить'
  }
];

let mail = $ref(""), login = $ref(""), pass = $ref(""), promo = $ref("");
const fields = [
  {
    icon: icon_mail,
    name: "Почта",
    placeholder: "Введите почту",
    on: [1, 2],
    value: mail,
    min: 6,
    max: 128
  },
  {
    icon: icon_user,
    name: "Логин",
    placeholder: "Введите логин",
    on: [0, 1, 2],
    value: login,
    min: 4,
    max: 32
  },
  {
    icon: icon_pass,
    name: "Пароль",
    placeholder: "Придумайте пароль",
    on: [0, 1],
    value: pass,
    type: "password",
    min: 6,
    max: 64
  },
  {
    icon: icon_star,
    name: "Промокод",
    placeholder: "Введите промокод (если есть)",
    on: [1],
    value: promo,
    max: 12
  }
];

let isSave = $ref(true);

const ClickNext = () => {
  const route_fields = fields.filter(x => x.on.includes(route));

  for(let i in route_fields) {
    const { min, max, value, name } = route_fields[i];
    if(min && min > value.length) return Notify.Send(NotifyType.error, `Поле ${name} не может содержать меньше ${min} символов`);
    if(max < value.length) return Notify.Send(NotifyType.error, `Поле ${name} не может содержать больше ${max} символов`);
  }

  const send_data = route_fields.map(x => x.value);
  if(route == 0) return Rage.trigger.server("Account:TryLogin", ...send_data, isSave);
  if(route == 1) return Rage.trigger.server("Account:TryRegister", ...send_data);
  if(route == 2) return Rage.trigger.server("Account:TryRecovery", ...send_data);
}

</script>

<style lang="stylus" module>
.login
  position relative
  bottom 10vh
  color #fff
  text-align center
  font-family 'Geometria'
  flex(column, ialign: center)

.logo_container
  width 100%
  flex(cont:center)

.logo
  height 12.5vh

.header
  font-weight: 700;
  font-size: 2.8vh;
  margin-top 2vh

.welcome
  font-weight: 400;
  font-size: 1.4vh;

  & span
    color #8A89F9

.input
  padding 0 0.6vw
  margin-top 1.75vh
  width 20vw
  height 5.5vh
  background rgba(255, 255, 255, 0.1)
  border-radius 0.5vw
  flex()

  & input
    width 100%
    font-family 'Geometria'
    margin-left 0.5vw
    font-weight: 400;
    font-size 1vw
    color #fff

    &::-webkit-input-placeholder
      color rgba(255, 255, 255, 0.5)

.field_icon
  width 1.1vw

.button
  width 20vw
  height 5.5vh
  margin-top 1.75vh
  background linear-gradient(180deg, #A5A4FF 0%, #8A89F9 100%)
  border-radius 0.5vw
  font-family 'Geometria'
  font-size 1vw
  font-weight: 400;
  color: #fff

.to_login
  margin-top 1vh
  text-align center
  font-family 'Geometria'
  font-size 0.9vw
  font-weight: 400;
  color: #fff
  opacity 0.5

.but_hrefs
  width 100%
  flex(cont:space-between)

.save
  margin-top 1.5vh
  flex(ialign: center)

.checkbox
  border-radius 0.3vw
  width 2.4vh
  height 2.4vh
  background rgba(255, 255, 255, 0.2)
  box-shadow 0 0 0 0.1vw rgba(138, 137, 249, 1)
  flex(column, center, ialign: center)

.check_text
  margin-left 0.5vw
  font-family 'Geometria'
  font-size 1.35vh
  font-weight: 400;
  color: #fff
  opacity 0.5

.check_yes
  border-radius 0.3vw
  width 75%
  height 75%
  background linear-gradient(180deg, #8A89F9 0%, #A5A4FF 100%)
</style>