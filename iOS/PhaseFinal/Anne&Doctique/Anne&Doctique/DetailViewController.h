//
//  DetailViewController.h
//  Anne&Doctique
//
//  Created by Kapi on 01/07/2014.
//  Copyright (c) 2014 Lionel. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface DetailViewController : UIViewController

@property (strong, nonatomic) id detailItem;

@property (weak, nonatomic) IBOutlet UILabel *detailDescriptionLabel;
@end
