<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col">
        <h1>Animal!</h1>

        <img
          src="https://static.boredpanda.com/blog/wp-content/uuuploads/cute-baby-animals/cute-baby-animals-10.jpg"
          alt
        />
        <img
          src="https://static.boredpanda.com/blog/wp-content/uuuploads/cute-baby-animals/cute-baby-animals-2.jpg"
          alt
        />
        <img
          src="https://i.insider.com/53a1f8176bb3f7e6106c6f1c?width=600&format=jpeg&auto=webp"
          alt
        />
        <img
          src="https://pbs.twimg.com/profile_images/3190433314/a533d3efa051bafc2f151db52a02502d.jpeg"
          alt
        />
        <img src="https://i.redd.it/kpmh84jfszk01.jpg" alt />
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "home",
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  }
};
</script>
