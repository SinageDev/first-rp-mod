<script setup lang="ts">
import Notify from "./components/Notify.vue";
</script>

<template>
  <router-view />
  <Notify></Notify>
</template>

<style lang="stylus">
*, *::before, *::after
  box-sizing border-box

body
  margin 0
  overflow hidden

input, button
  padding none
  border none
  outline none
  background none

@font-face
  font-family "Fira Code"
  src url("@assets/fonts/FiraCode.ttf")

@font-face
  font-family Geometria
  font-style normal
  font-weight 700
  src url("@assets/fonts/Geometria/Geometria-Bold.ttf")

@font-face
  font-family Geometria
  font-style normal
  font-weight 300
  src url("@assets/fonts/Geometria/Geometria-Regular.ttf")

@font-face
  font-family Montserrat
  font-style normal
  src url("@assets/fonts/Montserrat.ttf")
</style>
