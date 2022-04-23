<template>
<div :class="$style.background">
  <img :class="[$style.details, $style.left]" src="@images/login-detail-left.png" alt="Loading">
  <img :class="[$style.details, $style.right]" src="@images/login-detail-right.png" alt="Loading">
  <img :class="$style.character" src="@images/login-character.png">
  <Login></Login>
</div>
</template>

<script lang="ts" setup>
import Login from "@views/LogIn/components/login.vue";
</script>

<style lang="stylus" module>
.background
  size(100vw, 100vh)
  flex(column, center, ialign: center)
  background-image url("@assets/images/login-background.png"),
  linear-gradient(180deg, rgba(138, 137, 249, 0) 27.69%, rgba(138, 137, 249, 0.4) 134.77%),
  linear-gradient(189.93deg, #151B23 7.73%, #0D0F13 88.54%)
  background-size cover

.details
  position absolute
  width 37vw
  height 67vh

  &.left
    left 0
    bottom 0
  &.right
    right 0
    top 0

.character
  height 100%
  pos(right: 0, bottom: 0)
</style>