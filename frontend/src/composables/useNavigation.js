import { useRouter, useRoute } from 'vue-router'

export function useNavigation() {
  const router = useRouter()
  const route = useRoute()

  function goBackOrTo(targetRouteName) {
    if (window.history.length > 1) {
      router.back()
    } else {
      router.push({ name: targetRouteName })
    }
  }

  return {
    goBackOrTo,
    router,
    route,
  }
}
