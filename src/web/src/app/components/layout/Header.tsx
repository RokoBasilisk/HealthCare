"use client";
import { useEffect, useState } from "react";
import HeaderItem from "./HeaderItem";
import { homeNavigator } from "@/app/utils/navigator";

export default function Navbar() {
  const [isMenuModal, setIsMenuModal] = useState(false);
  useEffect(() => {
   require('bootstrap/dist/js/bootstrap');
 }, [])
  return (
    <header>
      <nav className="navbar navbar-expand-lg navbar-light w-100">
        <div className="container px-3">
          <a className="navbar-brand" href="./index.html">
            <img src="/next.svg" alt="Next.js Logo" width={180} height={37} />
          </a>
          <button className="navbar-toggler offcanvas-nav-btn" type="button">
            <i className="bi bi-list"></i>
          </button>
          <div
            className="offcanvas offcanvas-start offcanvas-nav"
            style={{ width: "20rem" }}
          >
            <div className="offcanvas-header">
              <a href="./index.html" className="text-inverse">
                <img
                  src="/next.svg"
                  alt="Next.js Logo"
                  width={180}
                  height={37}
                />
              </a>
              <button
                type="button"
                className="btn-close"
                data-bs-dismiss="offcanvas"
                aria-label="Close"
              ></button>
            </div>
            <div className="offcanvas-body pt-0 align-items-center">
              <ul className="navbar-nav mx-auto align-items-lg-center">
                <li className="nav-item dropdown">
                  <a
                    className="nav-link dropdown-toggle"
                    href="#"
                    role="button"
                    data-bs-toggle="dropdown"
                    aria-expanded="false"
                  >
                    Landings
                  </a>
                  <ul className="dropdown-menu">
                    <HeaderItem
                      params={{
                        displayIcon: "",
                        displayText: "Landing Overview",
                        href: homeNavigator.HOME_INDEX(),
                      }}
                    />
                    <HeaderItem
                      params={{
                        displayIcon: "",
                        displayText: "Saas v.1",
                        href: "./landing-sass-v1.html",
                      }}
                    />
                    <HeaderItem
                      params={{
                        displayIcon: "",
                        displayText: "Sass v.2",
                        href: "./landing-sass-v2.html",
                      }}
                    />
                    <HeaderItem
                      params={{
                        displayIcon: "",
                        displayText: "Accounting",
                        href: "./landing-accounting.html",
                      }}
                    />
                    <HeaderItem
                      params={{
                        displayIcon: "",
                        displayText: "Finance",
                        href: "./landing-finance.html",
                      }}
                    />
                    <HeaderItem
                      params={{
                        displayIcon: "",
                        displayText: "Jamstack Agency",
                        href: "./landing-jamstack-agancy.html",
                      }}
                    />
                    <HeaderItem
                      params={{
                        displayIcon: "",
                        displayText: "Conference",
                        href: "./landing-conference.html",
                      }}
                    />
                    <HeaderItem
                      params={{
                        displayIcon: "",
                        displayText: "Personal",
                        href: "./landing-personal.html",
                      }}
                    />
                  </ul>
                </li>
                <li className="nav-item dropdown">
                  <a
                    className="nav-link dropdown-toggle"
                    href="#"
                    role="button"
                    data-bs-toggle="dropdown"
                    aria-expanded="false"
                  >
                    Pages
                  </a>
                  <div className="dropdown-menu dropdown-menu-xxl">
                    <div className="row row-cols-lg-4 row-cols-1 g-0">
                      <div className="col">
                        <div>
                          <div>
                            <div className="dropdown-header">Blog</div>
                            <a
                              className="dropdown-item"
                              href="./blog-list-view.html"
                            >
                              List View
                            </a>
                            <a className="dropdown-item" href="./blog.html">
                              Grid View
                            </a>
                            <a
                              className="dropdown-item"
                              href="./blog-grid-thumbnail.html"
                            >
                              Grid View v.2
                            </a>
                            <a
                              className="dropdown-item"
                              href="./blog-sidebar.html"
                            >
                              Sidebar
                            </a>
                            <a
                              className="dropdown-item"
                              href="./blog-category.html"
                            >
                              Category
                            </a>
                            <a
                              className="dropdown-item"
                              href="./blog-single.html"
                            >
                              Single Post
                            </a>
                          </div>
                          <div className="mt-3">
                            <div className="dropdown-header">About</div>
                            <a className="dropdown-item" href="./about.html">
                              About v.1
                            </a>
                            <a className="dropdown-item" href="./about-v2.html">
                              About v.2
                            </a>
                          </div>
                        </div>
                      </div>
                      <div className="col">
                        <div className="mt-3 mt-lg-0">
                          <div>
                            <div className="dropdown-header">Service</div>
                            <a
                              className="dropdown-item"
                              href="./service-v1.html"
                            >
                              Service v.1
                            </a>
                            <a
                              className="dropdown-item"
                              href="./service-v2.html"
                            >
                              Service v.2
                            </a>
                            <a
                              className="dropdown-item"
                              href="./service-v3.html"
                            >
                              Service v.3
                            </a>
                          </div>
                          <div className="mt-3">
                            <div className="dropdown-header">Events</div>

                            <a className="dropdown-item" href="./events.html">
                              List
                            </a>
                            <a
                              className="dropdown-item"
                              href="./event-single.html"
                            >
                              Single
                            </a>
                          </div>
                          <div className="mt-3">
                            <div className="dropdown-header">Contact</div>

                            <a
                              className="dropdown-item"
                              href="./contact-1.html"
                            >
                              Contact Us
                            </a>
                            <a
                              className="dropdown-item"
                              href="./contact-2.html"
                            >
                              Contact Sales
                            </a>
                          </div>
                        </div>
                      </div>
                      <div className="col">
                        <div className="mt-3 mt-lg-0">
                          <div>
                            <div className="dropdown-header">Portfolio</div>

                            <a
                              className="dropdown-item"
                              href="./portfolio.html"
                            >
                              Grid View
                            </a>

                            <a
                              className="dropdown-item"
                              href="./portfolio-single.html"
                            >
                              Single View
                            </a>
                          </div>
                          <div className="mt-3">
                            <div className="dropdown-header">Pricing</div>
                            <a
                              className="dropdown-item"
                              href="./pricing-v1.html"
                            >
                              Pricing v.1
                            </a>
                            <a
                              className="dropdown-item"
                              href="./pricing-v2.html"
                            >
                              Pricing v.2
                            </a>
                          </div>
                          <div className="mt-3">
                            <div className="dropdown-header">Career</div>
                            <a className="dropdown-item" href="./career.html">
                              Career
                            </a>
                          </div>
                        </div>
                      </div>
                      <div className="col">
                        <div className="mt-3 mt-lg-0">
                          <div>
                            <div className="dropdown-header">Integration</div>
                            <a
                              className="dropdown-item"
                              href="./integration.html"
                            >
                              Grid View
                            </a>
                            <a
                              className="dropdown-item"
                              href="./integration-single.html"
                            >
                              Single
                            </a>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </li>
                <li className="nav-item dropdown dropdown-fullwidth">
                  <a
                    className="nav-link dropdown-toggle"
                    href="#"
                    role="button"
                    data-bs-toggle="dropdown"
                    aria-expanded="false"
                  >
                    Blocks
                  </a>
                  <div className="dropdown-menu p-4">
                    <div className="row row-cols-xl-6 row-cols-lg-5 row-cols-1 gx-lg-4">
                      <div className="col">
                        <a
                          className="dropdown-item d-block px-0 mb-lg-3"
                          href="./blocks/hero.html"
                        >
                          <div className="rounded d-none d-lg-block mb-lg-2">
                            <img
                              className="w-100 rounded-2"
                              src="./assets/images/block/hero-snippets-bootstrap.svg"
                              alt=""
                            />
                          </div>
                          <span>Hero</span>
                        </a>
                      </div>
                      <div className="col">
                        <a
                          className="dropdown-item d-block px-0 mb-lg-3"
                          href="./blocks/navbar.html"
                        >
                          <div className="rounded d-none d-lg-block mb-lg-2">
                            <img
                              className="w-100 rounded-2"
                              src="./assets/images/block/header-snippets-bootstrap.svg"
                              alt=""
                            />
                          </div>
                          <span>Navbar</span>
                        </a>
                      </div>
                      <div className="col">
                        <a
                          className="dropdown-item d-block px-0 mb-lg-3"
                          href="./blocks/about.html"
                        >
                          <div className="rounded d-none d-lg-block mb-lg-2">
                            <img
                              className="w-100 rounded-2"
                              src="./assets/images/block/about-snippets-bootstrap.svg"
                              alt=""
                            />
                          </div>
                          <span>About</span>
                        </a>
                      </div>
                      <div className="col">
                        <a
                          className="dropdown-item d-block px-0 mb-lg-3"
                          href="./blocks/blog.html"
                        >
                          <div className="rounded d-none d-lg-block mb-lg-2">
                            <img
                              className="w-100 rounded-2"
                              src="./assets/images/block/blog-snippets-bootstrap.svg"
                              alt=""
                            />
                          </div>
                          <span>Blog</span>
                        </a>
                      </div>
                      <div className="col">
                        <a
                          className="dropdown-item d-block px-0 mb-lg-3"
                          href="./blocks/carousel.html"
                        >
                          <div className="rounded d-none d-lg-block mb-lg-2">
                            <img
                              className="w-100 rounded-2"
                              src="./assets/images/block/carousel-snippets-bootstrap.svg"
                              alt=""
                            />
                          </div>
                          <span>Carousel</span>
                        </a>
                      </div>
                      <div className="col">
                        <a
                          className="dropdown-item d-block px-0 mb-lg-3"
                          href="./blocks/cta.html"
                        >
                          <div className="rounded d-none d-lg-block mb-lg-2">
                            <img
                              className="w-100 rounded-2"
                              src="./assets/images/block/call-to-action-snippets-bootstrap.svg"
                              alt=""
                            />
                          </div>
                          <span>Call to Action</span>
                        </a>
                      </div>
                      <div className="col">
                        <a
                          className="dropdown-item d-block px-0 mb-lg-3"
                          href="./blocks/clients.html"
                        >
                          <div className="rounded d-none d-lg-block mb-lg-2">
                            <img
                              className="w-100 rounded-2"
                              src="./assets/images/block/clients-logo-snippets-bootstrap.svg"
                              alt=""
                            />
                          </div>
                          <span>Client</span>
                        </a>
                      </div>
                      <div className="col">
                        <a
                          className="dropdown-item d-block px-0 mb-lg-3"
                          href="./blocks/contact.html"
                        >
                          <div className="rounded d-none d-lg-block mb-lg-2">
                            <img
                              className="w-100 rounded-2"
                              src="./assets/images/block/contact-section-example.svg"
                              alt=""
                            />
                          </div>
                          <span>Contact</span>
                        </a>
                      </div>
                      <div className="col">
                        <a
                          className="dropdown-item d-block px-0 mb-lg-3"
                          href="./blocks/form.html"
                        >
                          <div className="rounded d-none d-lg-block mb-lg-2">
                            <img
                              className="w-100 rounded-2"
                              src="./assets/images/block/form-snippets-bootstrap.svg"
                              alt=""
                            />
                          </div>
                          <span>Form</span>
                        </a>
                      </div>
                      <div className="col">
                        <a
                          className="dropdown-item d-block px-0 mb-lg-3"
                          href="./blocks/faq.html"
                        >
                          <div className="rounded d-none d-lg-block mb-lg-2">
                            <img
                              className="w-100 rounded-2"
                              src="./assets/images/block/faq-section-example.svg"
                              alt=""
                            />
                          </div>
                          <span>FAQ</span>
                        </a>
                      </div>
                      <div className="col">
                        <a
                          className="dropdown-item d-block px-0 mb-lg-3"
                          href="./blocks/team.html"
                        >
                          <div className="rounded d-none d-lg-block mb-lg-2">
                            <img
                              className="w-100 rounded-2"
                              src="./assets/images/block/team-snippets-bootstrap.svg"
                              alt=""
                            />
                          </div>
                          <span>Team</span>
                        </a>
                      </div>
                      <div className="col">
                        <a
                          className="dropdown-item d-block px-0 mb-lg-3"
                          href="./blocks/footer.html"
                        >
                          <div className="rounded d-none d-lg-block mb-lg-2">
                            <img
                              className="w-100 rounded-2"
                              src="./assets/images/block/footer-snippets-bootstrap.svg"
                              alt=""
                            />
                          </div>
                          <span>Footer</span>
                        </a>
                      </div>
                      <div className="col">
                        <a
                          className="dropdown-item d-block px-0 mb-lg-3"
                          href="./blocks/features.html"
                        >
                          <div className="rounded d-none d-lg-block mb-lg-2">
                            <img
                              className="w-100 rounded-2"
                              src="./assets/images/block/feature-snippets-bootstrap.svg"
                              alt=""
                            />
                          </div>
                          <span>Features</span>
                        </a>
                      </div>
                      <div className="col">
                        <a
                          className="dropdown-item d-block px-0 mb-lg-3"
                          href="./blocks/integration.html"
                        >
                          <div className="rounded d-none d-lg-block mb-lg-2">
                            <img
                              className="w-100 rounded-2"
                              src="./assets/images/block/integration-snippets-bootstrap.svg"
                              alt=""
                            />
                          </div>
                          <span>Integration</span>
                        </a>
                      </div>
                      <div className="col">
                        <a
                          className="dropdown-item d-block px-0 mb-lg-3"
                          href="./blocks/location.html"
                        >
                          <div className="rounded d-none d-lg-block mb-lg-2">
                            <img
                              className="w-100 rounded-2"
                              src="./assets/images/block/location-snippets-bootstrap.svg"
                              alt=""
                            />
                          </div>
                          <span>Location</span>
                        </a>
                      </div>
                      <div className="col">
                        <a
                          className="dropdown-item d-block px-0 mb-lg-3"
                          href="./blocks/portfolio.html"
                        >
                          <div className="rounded d-none d-lg-block mb-lg-2">
                            <img
                              className="w-100 rounded-2"
                              src="./assets/images/block/portfolio-snippets-bootstrap.svg"
                              alt=""
                            />
                          </div>
                          <span>Portfolio</span>
                        </a>
                      </div>
                      <div className="col">
                        <a
                          className="dropdown-item d-block px-0 mb-lg-3"
                          href="./blocks/process.html"
                        >
                          <div className="rounded d-none d-lg-block mb-lg-2">
                            <img
                              className="w-100 rounded-2"
                              src="./assets/images/block/process-snippets-bootstrap.svg"
                              alt=""
                            />
                          </div>
                          <span>Process</span>
                        </a>
                      </div>
                      <div className="col">
                        <a
                          className="dropdown-item d-block px-0 mb-lg-3"
                          href="./blocks/pricing.html"
                        >
                          <div className="rounded d-none d-lg-block mb-lg-2 bg-gray-200">
                            <img
                              className="w-100 rounded-2"
                              src="./assets/images/block/pricing-snippets-bootstrap.svg"
                              alt=""
                            />
                          </div>
                          <span>Pricing</span>
                        </a>
                      </div>

                      <div className="col">
                        <a
                          className="dropdown-item d-block px-0 mb-lg-3"
                          href="./blocks/facts.html"
                        >
                          <div className="rounded d-none d-lg-block mb-lg-2">
                            <img
                              className="w-100 rounded-2"
                              src="./assets/images/block/stats-snippets-bootstrap.svg"
                              alt=""
                            />
                          </div>
                          <span>Stats</span>
                        </a>
                      </div>
                      <div className="col">
                        <a
                          className="dropdown-item d-block px-0 mb-lg-3"
                          href="./blocks/testimonails.html"
                        >
                          <div className="rounded d-none d-lg-block mb-lg-2">
                            <img
                              className="w-100 rounded-2"
                              src="./assets/images/block/testimonial-snippets-bootstrap.svg"
                              alt=""
                            />
                          </div>
                          <span>Testimonials</span>
                        </a>
                      </div>
                    </div>
                  </div>
                </li>
                <li className="nav-item dropdown">
                  <a
                    className="nav-link dropdown-toggle"
                    href="#"
                    role="button"
                    data-bs-toggle="dropdown"
                    aria-expanded="false"
                  >
                    Accounts
                  </a>
                  <ul className="dropdown-menu">
                    <li>
                      <a
                        className="dropdown-item"
                        href="./account-profile.html"
                      >
                        Profile
                      </a>
                    </li>
                    <li>
                      <a
                        className="dropdown-item"
                        href="./account-security.html"
                      >
                        Security
                      </a>
                    </li>
                    <li>
                      <a
                        className="dropdown-item"
                        href="./account-billing.html"
                      >
                        Billing
                      </a>
                    </li>
                    <li>
                      <a className="dropdown-item" href="./account-team.html">
                        Team
                      </a>
                    </li>
                    <li>
                      <a
                        className="dropdown-item"
                        href="./account-notification.html"
                      >
                        Notifications
                      </a>
                    </li>
                    <li>
                      <a
                        className="dropdown-item"
                        href="./account-app-integration.html"
                      >
                        Integration
                      </a>
                    </li>
                    <li>
                      <a
                        className="dropdown-item"
                        href="./account-device-session.html"
                      >
                        Session
                      </a>
                    </li>
                    <li>
                      <a
                        className="dropdown-item"
                        href="./account-social-links.html"
                      >
                        Social
                      </a>
                    </li>
                    <li>
                      <a
                        className="dropdown-item"
                        href="./account-appearance.html"
                      >
                        Appearance
                      </a>
                    </li>
                    <li className="dropdown-submenu dropend">
                      <a className="dropdown-item dropdown-toggle" href="#">
                        Authentication
                      </a>
                      <ul className="dropdown-menu">
                        <li className="dropdown-header">Simple</li>

                        <li>
                          <a className="dropdown-item" href="./signin.html">
                            Sign In
                          </a>
                        </li>
                        <li>
                          <a className="dropdown-item" href="./signup.html">
                            Sign Up
                          </a>
                        </li>
                        <li>
                          <a
                            className="dropdown-item"
                            href="./forget-password.html"
                          >
                            Forget Password
                          </a>
                        </li>
                        <li>
                          <a
                            className="dropdown-item"
                            href="./reset-password.html"
                          >
                            Reset Password
                          </a>
                        </li>
                        <li>
                          <a
                            className="dropdown-item"
                            href="./otp-varification.html"
                          >
                            OTP Varification
                          </a>
                        </li>
                        <li>
                          <hr className="dropdown-divider" />
                        </li>
                        <li className="dropdown-header">Side Cover</li>

                        <li>
                          <a className="dropdown-item" href="./signin-v2.html">
                            Sign In
                          </a>
                        </li>

                        <li>
                          <a className="dropdown-item" href="./signup-v2.html">
                            Sign Up
                          </a>
                        </li>

                        <li>
                          <a
                            className="dropdown-item"
                            href="./forget-password-v2.html"
                          >
                            Forget Password
                          </a>
                        </li>
                        <li>
                          <a
                            className="dropdown-item"
                            href="./reset-password-v2.html"
                          >
                            Reset Password
                          </a>
                        </li>
                        <li>
                          <a
                            className="dropdown-item"
                            href="./otp-varification-v2.html"
                          >
                            OTP Varification
                          </a>
                        </li>
                      </ul>
                    </li>
                    <li className="dropdown-submenu dropend">
                      <a className="dropdown-item dropdown-toggle" href="#">
                        Utility
                      </a>
                      <ul className="dropdown-menu">
                        <li>
                          <a className="dropdown-item" href="./404-error.html">
                            404 Error
                          </a>
                        </li>
                        <li>
                          <a className="dropdown-item" href="./changelog.html">
                            Changelog
                          </a>
                        </li>
                      </ul>
                    </li>
                  </ul>
                </li>
                <li className="nav-item dropdown">
                  <a
                    className="nav-link dropdown-toggle"
                    href="#"
                    id="navbarDropdown"
                    role="button"
                    data-bs-toggle="dropdown"
                    aria-haspopup="true"
                    aria-expanded="false"
                  >
                    Docs
                  </a>
                  <div
                    className="dropdown-menu dropdown-menu-md"
                    aria-labelledby="navbarDropdown"
                  >
                    <a
                      className="dropdown-item mb-3 text-body"
                      href="./docs/index.html"
                    >
                      <div className="d-flex align-items-center">
                        <i className="bi bi-file-text fs-4 text-primary"></i>
                        <div className="ms-3 lh-1">
                          <h5 className="mb-1">Documentations</h5>
                          <p className="mb-0 fs-6">
                            Browse the all documentation
                          </p>
                        </div>
                      </div>
                    </a>

                    <a
                      className="dropdown-item text-body"
                      href="./docs/changelog.html"
                    >
                      <div className="d-flex align-items-center">
                        <i className="bi bi-clipboard fs-4 text-primary"></i>
                        <div className="ms-3 lh-1">
                          <h5 className="mb-1">
                            Changelog
                            <span
                              className="text-primary ms-1"
                              id="changelog"
                            ></span>
                          </h5>
                          <p className="mb-0 fs-6">See what's new</p>
                        </div>
                      </div>
                    </a>
                  </div>
                </li>
              </ul>
              <div className="mt-3 mt-lg-0 d-flex align-items-center">
                <a href="./signin.html" className="btn btn-light mx-2">
                  Login
                </a>
                <a href="./signup.html" className="btn btn-primary">
                  Create account
                </a>
              </div>
            </div>
          </div>
        </div>
      </nav>
    </header>
  );
}
