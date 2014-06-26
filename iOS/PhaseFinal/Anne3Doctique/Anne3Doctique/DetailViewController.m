//
//  DetailViewController.m
//  Anne3Doctique
//
//  Created by Kapi on 19/06/2014.
//  Copyright (c) 2014 Lionel. All rights reserved.
//

#import "DetailViewController.h"
@interface DetailViewController () - (void)configureView;
@end
@implementation DetailViewController
@synthesize texteAAfficher = _texteAAfficher;
@synthesize detailItem = _detailItem;
@synthesize detailDescriptionLabel = _detailDescriptionLabel; @synthesize donneeRecue = _donneeRecue;

#pragma mark - Managing the detail item
- (void)setDetailItem:(id)newDetailItem
{
    if (_detailItem != newDetailItem) {
        _detailItem = newDetailItem;
        // Update the view.
        [self configureView]; }
}
- (void)configureView
{
}
- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Release any cached data, images, etc that aren't in use.
}
#pragma mark - View lifecycle
- (void)viewDidLoad
{
    [super viewDidLoad];
    // Do any additional setup after loading the view, typically from a nib.
    [self configureView];
    _donneeRecue.text = _texteAAfficher;
}
- (void)viewDidUnload
{
    [self setDonneeRecue:nil];
    [super viewDidUnload];
    // Release any retained subviews of the main view. // e.g. self.myOutlet = nil;
}
- (void)viewWillAppear:(BOOL)animated
{
    [super viewWillAppear:animated];
}
- (void)viewDidAppear:(BOOL)animated
{
    [super viewDidAppear:animated];
}
- (void)viewWillDisappear:(BOOL)animated
{
    [super viewWillDisappear:animated];
}
- (void)viewDidDisappear:(BOOL)animated
{
    [super viewDidDisappear:animated];
}

-(BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation != UIInterfaceOrientationPortraitUpsideDown);
}
@end
