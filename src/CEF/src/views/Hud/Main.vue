<template>
  <div :class="$style.hud">
    <Chat/>
  </div>
</template>

<script setup lang="ts">
import Chat from "./components/chat.vue";
</script>

<style lang="stylus" module>
.hud
  width 100vw
  height 100vh
  position absolute
  left 0
  top 0
</style>