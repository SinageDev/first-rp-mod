export default [
  {
    path: '/',
    component: () => import("@views/LogIn/Main.vue")
  },
  {
    path: '/hud',
    component: () => import("@views/Hud/Main.vue")
  }
]